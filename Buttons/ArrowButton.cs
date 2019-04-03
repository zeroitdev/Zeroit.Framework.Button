// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ArrowButton.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region Arrow Button

    #region Enums    
    /// <summary>
    /// Enum representing button actions for <c><see cref="ZeroitArrowButton" /></c>
    /// </summary>
    public enum ButtonActions : int
    {
        /// <summary>
        /// The pressed
        /// </summary>
        PRESSED = 0x01,
        /// <summary>
        /// The focus
        /// </summary>
        FOCUS,
        /// <summary>
        /// The mouseover
        /// </summary>
        MOUSEOVER,
        /// <summary>
        /// The enabled
        /// </summary>
        ENABLED
    };

    #endregion

    #region Control    
    /// <summary>
    /// A class collection for rendering an arrow button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Description("Arrow Button Control")]
    [Designer(typeof(ArrowButtonDesigner))]
    public class ZeroitArrowButton : System.Windows.Forms.Control
    {

        #region Designer generated code
        /// <summary>
        /// Designer generated code
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ArrowButton
            // 
            this.Name = "ArrowButton";
            this.Size = new System.Drawing.Size(48, 48);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ArrowButton_MouseUp);
            this.MouseEnter += new System.EventHandler(this.ArrowButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ArrowButton_MouseLeave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrowButton_MouseDown);

        }
        #endregion

        #region Events / Delegates

        /// <summary>
        /// Delegate ArrowButtonClickDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void ArrowButtonClickDelegate(object sender, EventArgs e);
        /// <summary>
        /// Occurs when [on click event].
        /// </summary>
        public event ArrowButtonClickDelegate OnClickEvent;

        #endregion

        #region Members

        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.Container components = null;
        /// <summary>
        /// The m PNTS
        /// </summary>
        private Point[] m_pnts = null;                      // Array with the arrow points
        /// <summary>
        /// The m count PNT
        /// </summary>
        private Point m_CntPnt;                             // Centerpoint 
        /// <summary>
        /// The m gp
        /// </summary>
        GraphicsPath m_gp = new GraphicsPath();         // Build the arrow
        /// <summary>
        /// The m button state
        /// </summary>
        private BitArray m_ButtonState = new BitArray();    // actual button state ( pressed, focus etc. )
        /// <summary>
        /// The m n rot deg
        /// </summary>
        private int m_nRotDeg = 0;                          // Rotatin in degrees
        /// <summary>
        /// The m color s
        /// </summary>
        private Color m_ColorS = Color.WhiteSmoke;          // Used start-, endcolor for the OnPaint method
        /// <summary>
        /// The m color e
        /// </summary>
        private Color m_ColorE = Color.DarkGray;
        /// <summary>
        /// The m normal start color
        /// </summary>
        private Color m_NormalStartColor = Color.WhiteSmoke;// In normal state
        /// <summary>
        /// The m normal end color
        /// </summary>
        private Color m_NormalEndColor = Color.DarkGray;
        /// <summary>
        /// The m hover start color
        /// </summary>
        private Color m_HoverStartColor = Color.WhiteSmoke; // If Mousecursor is over
        /// <summary>
        /// The m hover end color
        /// </summary>
        private Color m_HoverEndColor = Color.DarkRed;

        #endregion

        #region Constants

        /// <summary>
        /// The minsize
        /// </summary>
        private const int MINSIZE = 24;                     // Minimum squaresize

        #endregion

        #region Properties / DesignerProperties

        /// <summary>
        /// Startcolor for the GradientBrush
        /// </summary>
        /// <value>The start color of the normal.</value>
        [Description("The start color"), Category("ArrowButton")]
        public Color NormalStartColor
        {
            get { return m_NormalStartColor; }
            set { m_NormalStartColor = value; Invalidate(); }

        }

        /// <summary>
        /// Endcolor for the GradientBrush
        /// </summary>
        /// <value>The end color of the normal.</value>
        [Description("The end color"), Category("ArrowButton")]
        public Color NormalEndColor
        {
            get { return m_NormalEndColor; }
            set
            {
                m_NormalEndColor = value;

                //Refresh ();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the start color of the hover.
        /// </summary>
        /// <value>The start color of the hover.</value>
        [Description("The hover start color"), Category("ArrowButton")]
        public Color HoverStartColor
        {
            get { return m_HoverStartColor; }
            set
            {
                m_HoverStartColor = value;
                //Refresh ();

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the end color of the hover.
        /// </summary>
        /// <value>The end color of the hover.</value>
        [Description("The hover end color"), Category("ArrowButton")]
        public Color HoverEndColor
        {
            get { return m_HoverEndColor; }
            set
            {
                m_HoverEndColor = value;

                //Refresh (); 

                Invalidate();

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [arrow enabled].
        /// </summary>
        /// <value><c>true</c> if [arrow enabled]; otherwise, <c>false</c>.</value>
        [Description("Is arrow enabled"), Category("ArrowButton")]
        public bool ArrowEnabled
        {
            get { return m_ButtonState[(int)ButtonActions.ENABLED]; }
            set
            {
                m_ButtonState[(int)ButtonActions.ENABLED] = value;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        [Description("Pointing direction"), Category("ArrowButton")]
        public int Rotation
        {
            get { return m_nRotDeg; }
            set
            {
                m_nRotDeg = value;
                Clear();
                Init();
                //Refresh ();

                Invalidate();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitArrowButton"/> class.
        /// </summary>
        public ZeroitArrowButton()
        {
            InitializeComponent();
            Init();
            // Make the paintings faster and flickerfree
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            // Inital state
            m_ButtonState[(int)ButtonActions.PRESSED] = false;
            m_ButtonState[(int)ButtonActions.ENABLED] = true;
            IncludeInConstructor();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Repaint ( recalc ) the arrow
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            Clear();
            Init();
            //Refresh();

            Invalidate();
        }

        /// <summary>
        /// Paint the arrow.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);

            if (m_ButtonState[(int)ButtonActions.MOUSEOVER] == true)
            {
                m_ColorS = HoverStartColor;
                m_ColorE = HoverEndColor;
            }
            else
            {
                m_ColorS = NormalStartColor;
                m_ColorE = NormalEndColor;
            }

            Rectangle rect = this.ClientRectangle;
            LinearGradientBrush b = new LinearGradientBrush(rect, m_ColorS, m_ColorE, 0, true);
            // no clipping at design time
            if (this.DesignMode != true)
            {
                e.Graphics.SetClip(m_gp);
            }
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(b, m_gp);
            b.Dispose();
            ColorArrowFrame(e, m_ButtonState);
            DrawArrowText(e.Graphics);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sequence to create the button
        /// </summary>
        private void Init()
        {
            // Check if clientrect is a square
            MakeSquare();

            // Make the arrow smaller than the panelwidth, because 
            // the diagonal from arrowhead to an edge from the arrowbottom,
            // is bigger than the panelwidth and so the edges were clipped
            // during rotation.
            int dx = this.Width - 3;

            // The arrow consist of eight points ( 0=7 )
            BuildInitialArrow(dx);

            // Calculate the CenterPoint position
            m_CntPnt = new Point(this.Width / 2, this.Width / 2);

            // Turn arrow around the CenterPoint
            RotateArrow(Rotation);

            // Prevent clipping
            MoveCenterPoint(dx);

            // Build the graphical path out of the arrowpoints
            GraphicsPathFromPoints(m_pnts, m_gp, m_CntPnt);

        }

        /// <summary>
        /// To prevent clipping of the arrow edges after an
        /// rotation, we shift the CenterPoint. For that we
        /// must only check the points 0 and 1
        /// </summary>
        /// <param name="dx">The dx.</param>
        private void MoveCenterPoint(int dx)
        {
            // Sector I
            if ((m_nRotDeg >= 0) && (m_nRotDeg <= 90))
            {
                int cy = (m_pnts[1].Y) - ((dx / 2));
                if (cy > 0)
                {
                    m_CntPnt.Y -= cy;
                }
                int cx = (m_pnts[0].X) + ((dx / 2));
                if (cx < 0)
                {
                    m_CntPnt.X -= cx;
                }
            }

            // Sector II
            if ((m_nRotDeg >= 91) && (m_nRotDeg <= 180))
            {
                int cy = (m_pnts[0].Y) - ((dx / 2));
                if (cy > 0)
                {
                    m_CntPnt.Y += cy;
                }
                int cx = (m_pnts[1].X) + ((dx / 2));
                if (cx < 0)
                {
                    m_CntPnt.X -= cx;
                }
            }

            // Sector III
            if ((m_nRotDeg >= 181) && (m_nRotDeg <= 270))
            {
                int cy = (m_pnts[1].Y) + ((dx / 2));
                if (cy < 0)
                {
                    m_CntPnt.Y -= cy;
                }
                int cx = (m_pnts[1].X) + ((dx / 2));
                if (cx < 0)
                {
                    m_CntPnt.X -= cx;
                }
            }

            // Sector IV
            if ((m_nRotDeg >= 271) && (m_nRotDeg <= 360))
            {
                int cy = (m_pnts[0].Y) - ((dx / 2));
                if (cy > 0)
                {
                    m_CntPnt.Y += cy;
                }
                int cx = (m_pnts[1].X) - ((dx / 2));
                if (cx > 0)
                {
                    m_CntPnt.X -= cx;
                }
            }
        }


        /// <summary>
        /// Build the startarrow. it is a upward pointing arrow.
        /// </summary>
        /// <param name="dx">The maximum height and width of the panel</param>
        private void BuildInitialArrow(int dx)
        {
            // The arrow consist of eight points
            m_pnts = new Point[8];

            // The initial points build an arrow in up-direction
            m_pnts[0] = new Point(-dx / 4, +dx / 2);
            m_pnts[1] = new Point(+dx / 4, +dx / 2);
            m_pnts[2] = new Point(+dx / 4, 0);
            m_pnts[3] = new Point(+dx / 2, 0);
            m_pnts[4] = new Point(0, -dx / 2);
            m_pnts[5] = new Point(-dx / 2, 0);
            m_pnts[6] = new Point(-dx / 4, 0);
            m_pnts[7] = new Point(-dx / 4, +dx / 2);
        }

        /// <summary>
        /// If the placeholder is not exact a square,
        /// make it a square
        /// </summary>
        private void MakeSquare()
        {
            this.SuspendLayout();
            if (this.Width < MINSIZE)
            {
                this.Size = new Size(MINSIZE, MINSIZE);
            }
            else
            {
                if (this.Size.Width < this.Size.Height)
                {
                    this.Size = new Size(this.Size.Width, this.Size.Width);
                }
                else
                {
                    this.Size = new Size(this.Size.Height, this.Size.Height);
                }
            }
            this.ResumeLayout();
        }


        /// <summary>
        /// Create the arrow as a GraphicsPath from the point array
        /// </summary>
        /// <param name="pnts">Array with points</param>
        /// <param name="gp">The GraphicsPath object</param>
        /// <param name="hs">Point with offset data</param>
        private void GraphicsPathFromPoints(Point[] pnts, GraphicsPath gp, Point hs)
        {
            for (int i = 0; i < pnts.Length - 1; i++)
            {
                gp.AddLine(hs.X + pnts[i].X, hs.Y + pnts[i].Y, hs.X + pnts[i + 1].X, hs.Y + pnts[i + 1].Y);
            }
        }


        /// <summary>
        /// Display a the text on the arrow
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawArrowText(Graphics g)
        {
            if (Text == String.Empty)
                return;
            StringFormat f = new StringFormat();
            f.Alignment = StringAlignment.Center;
            f.LineAlignment = StringAlignment.Center;
            float dx = 0;
            float dy = 0;
            if ((m_ButtonState[(int)ButtonActions.PRESSED]) &&
                 (m_ButtonState[(int)ButtonActions.ENABLED] == true))
            {
                dx = 1 / g.DpiX;
                dy = 1 / g.DpiY;
            }
            g.PageUnit = GraphicsUnit.Inch;
            g.TranslateTransform((ClientRectangle.Width / g.DpiX) / 2, (ClientRectangle.Height / g.DpiY) / 2);
            // to prevent that the text is not readable, add 90 degrees
            // to turn in a readable direction ( 175 and 330 are arbitrary values )
            if ((Rotation >= 175) && (Rotation <= 330))
            {
                g.RotateTransform(Rotation + 90);
            }
            else
            {
                g.RotateTransform(Rotation + 270);
            }
            Color c = ForeColor;
            if (m_ButtonState[(int)ButtonActions.ENABLED] == false)
            {
                c = SystemColors.GrayText;//.InactiveCaptionText;
            }
            g.DrawString(Text, Font, new SolidBrush(c), 0 + dx, 0 + dy, f);
        }

        /// <summary>
        /// Simply clear the points and reset the graphicpath
        /// </summary>
        private void Clear()
        {
            m_pnts = null;
            m_gp.Reset();
        }

        /// <summary>
        /// With different colors around the arrow we engender the 3d effect.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="butstate">The butstate.</param>
        private void ColorArrowFrame(PaintEventArgs e, BitArray butstate)
        {
            if (m_ButtonState[(int)ButtonActions.ENABLED])
            {
                Pen p1 = null;
                if (butstate[(int)ButtonActions.PRESSED] == false)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (m_pnts[i].Y <= m_pnts[i + 1].Y)
                        {
                            p1 = new Pen(SystemColors.ControlLightLight, 2);
                        }
                        else
                        {
                            p1 = new Pen(SystemColors.ControlDark, 2);
                        }
                        e.Graphics.DrawLine(p1, m_CntPnt.X + m_pnts[i].X, m_CntPnt.Y + m_pnts[i].Y, m_CntPnt.X + m_pnts[i + 1].X, m_CntPnt.Y + m_pnts[i + 1].Y);
                    }
                }

                if (butstate[(int)ButtonActions.PRESSED] == true)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (m_pnts[i].Y <= m_pnts[i + 1].Y)
                        {
                            p1 = new Pen(SystemColors.ControlDark, 2);
                        }
                        else
                        {
                            p1 = new Pen(SystemColors.ControlLightLight, 2);
                        }
                        e.Graphics.DrawLine(p1, m_CntPnt.X + m_pnts[i].X, m_CntPnt.Y + m_pnts[i].Y, m_CntPnt.X + m_pnts[i + 1].X, m_CntPnt.Y + m_pnts[i + 1].Y);
                    }
                }
            }
        }

        /// <summary>
        /// Rotate the arrow around the CenterPoint to get different
        /// pointing directions.
        /// </summary>
        /// <param name="nDeg">Rotation in degree</param>
        private void RotateArrow(int nDeg)
        {
            // only values between 0 and 360
            if (nDeg > 360)
            {
                nDeg -= 360;
            }

            m_nRotDeg = nDeg;
            double bog = (Math.PI / 180) * nDeg;
            double cosA = Math.Cos(bog);
            double sinA = Math.Sin(bog);

            for (int i = 0; i < 8; i++)
            {
                int a = m_pnts[i].X;
                int b = m_pnts[i].Y;

                double x = (a * cosA) - (b * sinA);
                double y = (b * cosA) + (a * sinA);

                m_pnts[i].X = (int)x;
                m_pnts[i].Y = (int)y;
            }
        }


        #endregion

        #region Mouseactions

        /// <summary>
        /// Handles the MouseUp event of the ArrowButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ArrowButton_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            m_ButtonState[(int)ButtonActions.PRESSED] = false;
            //Refresh();

            Invalidate();
        }

        /// <summary>
        /// Handles the MouseLeave event of the ArrowButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ArrowButton_MouseLeave(object sender, System.EventArgs e)
        {
            m_ButtonState[(int)ButtonActions.MOUSEOVER] = false;
            //Refresh();

            Invalidate();
        }

        /// <summary>
        /// Handles the MouseEnter event of the ArrowButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ArrowButton_MouseEnter(object sender, System.EventArgs e)
        {
            m_ButtonState[(int)ButtonActions.MOUSEOVER] = true;
            //Refresh();

            Invalidate();
        }

        /// <summary>
        /// Handles the MouseDown event of the ArrowButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ArrowButton_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            m_ButtonState[(int)ButtonActions.PRESSED] = true;
            //Refresh();
            Invalidate();
            OnArrowClick(e);
        }


        #endregion

        #region EventHandler function

        /// <summary>
        /// Handles the <see cref="E:ArrowClick" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void OnArrowClick(EventArgs e)
        {
            if (OnClickEvent != null)
            {
                OnClickEvent(this, e);
            }
        }

        #endregion

        #region Disposing

        /// <summary>
        /// Clear the used resources
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

        #endregion

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

    }
    #endregion

    #region Class Bitarray

    /// <summary>
    /// Class BitArray.
    /// </summary>
    public class BitArray
    {
        #region Constants

        /// <summary>
        /// The numbits
        /// </summary>
        const int NUMBITS = 32;     // Bits = int = 4 byte = 32 bits

        #endregion

        #region Members

        /// <summary>
        /// The m bits
        /// </summary>
        private int m_Bits;

        #endregion

        #region Indexer

        /// <summary>
        /// The Indexer for a 32 bit array
        /// </summary>
        /// <param name="BitPos">The bit position.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool this[int BitPos]
        {
            get
            {
                BitPosValid(BitPos);
                return ((m_Bits & (1 << (BitPos % 8))) != 0);
            }
            set
            {
                BitPosValid(BitPos);
                // Set the bit to 1
                if (value)
                {
                    m_Bits |= (1 << (BitPos % 8));
                }
                // Set the bit to 0
                else
                {
                    m_Bits &= ~(1 << (BitPos % 8));
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check if the wanted bit is in a valid Range
        /// </summary>
        /// <param name="BitPos">The bit position.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        private void BitPosValid(int BitPos)
        {
            if ((BitPos < 0) || (BitPos >= NUMBITS))
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Clear all bits in the "bitarray"
        /// </summary>
        public void Clear()
        {
            m_Bits = 0x00;
        }

        #endregion
    }

    #endregion

    #region Class ArrowButtonDesigner

    /// <summary>
    /// Class ArrowButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    public class ArrowButtonDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowButtonDesigner"/> class.
        /// </summary>
        public ArrowButtonDesigner()
        {
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Posts the filter properties.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            Properties.Remove("AllowDrop");
            Properties.Remove("BackColor");
            Properties.Remove("BackgroundImage");
            Properties.Remove("ContextMenu");
            Properties.Remove("FlatStyle");
            Properties.Remove("Image");
            Properties.Remove("ImageAlign");
            Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
            Properties.Remove("TextAlign");
            Properties.Remove("Enabled");
        }

        #endregion
    }

    #endregion

    #endregion


}
