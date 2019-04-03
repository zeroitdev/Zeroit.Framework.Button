// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="MovingBorderButton.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Zeroit.Framework.Button
{

    #region MovingBorder Button

    #region Graphics Buffer


    // ****************************************** class GraphicsBuffer

    /// <summary>
    /// Class GraphicsBuffer.
    /// </summary>
    public class GraphicsBuffer
    {
        /// <summary>
        /// The bitmap
        /// </summary>
        Bitmap bitmap;
        /// <summary>
        /// The graphic
        /// </summary>
        Graphics graphic;
        /// <summary>
        /// The height
        /// </summary>
        int height;
        /// <summary>
        /// The name
        /// </summary>
        string name;
        /// <summary>
        /// The width
        /// </summary>
        int width;

        // ******************************************** GraphicsBuffer

        /// <summary>
        /// constructor for the GraphicsBuffer
        /// </summary>
        public GraphicsBuffer()
        {

            Width = 0;
            Height = 0;
            Name = String.Empty;
        }

        // **************************************************** Bitmap

        /// <summary>
        /// Gets or sets the bitmap.
        /// </summary>
        /// <value>The bitmap.</value>
        public Bitmap Bitmap
        {

            get
            {
                return (bitmap);
            }

            set
            {
                bitmap = value;
            }
        }

        // **************************************************** Height

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {

            get
            {
                return (height);
            }

            set
            {
                if (value != height)
                {
                    height = value;
                }
            }
        }

        // ****************************************************** Name

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {

            get
            {
                return (name);
            }

            set
            {
                if (value != name)
                {
                    name = value;
                }
            }
        }

        // ***************************************************** Width

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {

            get
            {
                return (width);
            }

            set
            {
                if (value != width)
                {
                    width = value;
                }
            }
        }

        // ************************************** CreateGraphicsBuffer

        /// <summary>
        /// completes the creation of the GraphicsBuffer object
        /// </summary>
        /// <param name="name">optional name of the graphics buffer</param>
        /// <param name="width">width of the bitmap</param>
        /// <param name="height">height of the bitmap</param>
        /// <returns>true, if GraphicsBuffer created; otherwise, false</returns>
        public bool CreateGraphicsBuffer(string name,
                                           int width,
                                           int height)
        {
            bool success = true;

            if (graphic != null)
            {
                graphic.Dispose();
                graphic = null;
            }

            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }

            Width = 0;
            Height = 0;
            Name = String.Empty;

            if ((width == 0) || (height == 0))
            {
                success = false;
            }
            else
            {
                Width = width;
                Height = height;
                Name = name;

                bitmap = new Bitmap(Width, Height);
                graphic = Graphics.FromImage(bitmap);

                success = true;
            }

            return (success);
        }

        // ************************************** CreateGraphicsBuffer

        /// <summary>
        /// Creates the graphics buffer.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CreateGraphicsBuffer(int width,
                                           int height)
        {

            return (CreateGraphicsBuffer(String.Empty,
                                            width,
                                            height));
        }

        // ********************************** InitializeGraphicsBuffer

        /// <summary>
        /// Initializes the graphics buffer.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool InitializeGraphicsBuffer(string name,
                                               int width,
                                               int height)
        {

            return (CreateGraphicsBuffer(name,
                                            width,
                                            height));
        }

        // *********************************************** ClearBitmap

        /// <summary>
        /// Clears the bitmap.
        /// </summary>
        /// <param name="background_color">Color of the background.</param>
        public void ClearBitmap(Color background_color)
        {

            Graphic.Clear(background_color);
        }

        // ************************************** DeleteGraphicsBuffer

        /// <summary>
        /// deletes the current GraphicsBuffer
        /// </summary>
        /// <returns>null, always</returns>
        public GraphicsBuffer DeleteGraphicsBuffer()
        {

            if (graphic != null)
            {
                graphic.Dispose();
                graphic = null;
            }

            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }

            Width = 0;
            Height = 0;
            Name = String.Empty;

            return (null);
        }

        // *************************************************** Graphic

        /// <summary>
        /// returns the current Graphic Graphics object
        /// </summary>
        /// <value>The graphic.</value>
        public Graphics Graphic
        {

            get
            {
                return (graphic);
            }
        }

        // ************************************** GraphicsBufferExists

        /// <summary>
        /// returns true if the grapgics object exists; false,
        /// otherwise
        /// </summary>
        /// <value><c>true</c> if [graphics buffer exists]; otherwise, <c>false</c>.</value>
        public bool GraphicsBufferExists
        {

            get
            {
                return (graphic != null);
            }
        }

        // ******************************************* ColorAtLocation

        /// <summary>
        /// given a point in the graphic bitmap, returns the GDI
        /// Color at that point
        /// </summary>
        /// <param name="location">location in the bitmap from which the color is to be
        /// returned</param>
        /// <returns>if the location is within the bitmap, the color at the
        /// location; otherwise, Black</returns>
        public Color ColorAtLocation(Point location)
        {
            Color color = Color.Black;

            if (((location.X > 0) &&
                   (location.X <= Width)) &&
                 ((location.Y > 0) &&
                   (location.Y <= Height)))
            {
                color = this.bitmap.GetPixel(location.X,
                                               location.Y);
            }

            return (color);
        }

        // ************************************** RenderGraphicsBuffer

        /// <summary>
        /// Renders the buffer to the graphic object identified by
        /// graphic
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public void RenderGraphicsBuffer(Graphics graphics)
        {

            if (bitmap != null)
            {
                graphics.DrawImage(
                            bitmap,
                            new Rectangle(0, 0, Width, Height),
                            new Rectangle(0, 0, Width, Height),
                            GraphicsUnit.Pixel);
            }
        }

        // ********************************************* ClearGraphics

        /// <summary>
        /// clears the graphic object identified by graphic
        /// </summary>
        /// <param name="background_color">background color to be used to clear graphic</param>
        public void ClearGraphics(Color background_color)
        {

            Graphic.Clear(background_color);
        }

    } // class GraphicsBuffer

    #endregion

    #region Control

    // ************************************** class MovingBorderButton    
    /// <summary>
    /// A class collection for rendering a moving representing.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    [Designer(typeof(ZeroitButtonMovingBorderButtonDesigner))]
    public class ZeroitMoveBorderButton : System.Windows.Forms.Button
    {
        #region Constants


        // ******************************************* class constants

        /// <summary>
        /// The dash length
        /// </summary>
        const int DASH_LENGTH = 4;
        /// <summary>
        /// The pen width
        /// </summary>
        const int PEN_WIDTH = 2;
        /// <summary>
        /// The timer interval
        /// </summary>
        const double TIMER_INTERVAL = 100.0;
        // border edge constants
        /// <summary>
        /// The top
        /// </summary>
        const int TOP = 0;
        /// <summary>
        /// The right
        /// </summary>
        const int RIGHT = TOP + 1;
        /// <summary>
        /// The bottom
        /// </summary>
        const int BOTTOM = RIGHT + 1;
        /// <summary>
        /// The left
        /// </summary>
        const int LEFT = BOTTOM + 1;
        /// <summary>
        /// The edges
        /// </summary>
        const int EDGES = LEFT + 1;
        #endregion

        #region Variables



        // ******************************************* class variables

        /// <summary>
        /// The dash length
        /// </summary>
        int dash_length = DASH_LENGTH;
        /// <summary>
        /// The dash pattern
        /// </summary>
        float[] dash_pattern = new float[]
                                {
                                DASH_LENGTH / PEN_WIDTH,
                                DASH_LENGTH / PEN_WIDTH
                                };
        /// <summary>
        /// The end at
        /// </summary>
        Point[] end_at = new Point[EDGES];
        /// <summary>
        /// The initialized
        /// </summary>
        bool initialized = false;
        /// <summary>
        /// The moving border graphic
        /// </summary>
        GraphicsBuffer moving_border_graphic = null;
        /// <summary>
        /// The move button border
        /// </summary>
        bool move_button_border = false;
        /// <summary>
        /// The moving border pen
        /// </summary>
        Pen moving_border_pen = null;
        /// <summary>
        /// The pen width
        /// </summary>
        int pen_width = PEN_WIDTH;
        /// <summary>
        /// The start at
        /// </summary>
        Point[] start_at = new Point[EDGES];
        /// <summary>
        /// The timer
        /// </summary>
        System.Timers.Timer timer = null;
        /// <summary>
        /// The timer interval
        /// </summary>
        double timer_interval = TIMER_INTERVAL;
        #endregion

        #region Memory_Cleanup


        // ******************************************** memory_cleanup

        /// <summary>
        /// cleans up any GDI or timer objects to avoid memory leaks
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void memory_cleanup(object sender,
                              EventArgs e)
        {

            if (timer != null)
            {
                if (timer.Enabled)
                {
                    timer.Elapsed -= new ElapsedEventHandler(tick);
                    timer.Stop();
                }
                timer = null;
            }

            if (moving_border_graphic != null)
            {
                moving_border_graphic.DeleteGraphicsBuffer();
            }

            if (moving_border_pen != null)
            {
                moving_border_pen.Dispose();
                moving_border_pen = null;
            }
        }

        #endregion

        #region Contrasting Color


        // ***************************************** contrasting_color

        /// <summary>
        /// determines the color (black or white) that contrasts with
        /// the given color
        /// </summary>
        /// <param name="color">color for which to find its contrasting color</param>
        /// <returns>the contrasting color (black or white)</returns>
        /// <reference>
        /// http://stackoverflow.com/questions/1855884/
        /// determine-font-color-based-on-background-color
        /// </reference>
        Color contrasting_color(Color color)
        {
            double a;
            int d = 0;

            a = 1.0 - ((0.299 * color.R +
                          0.587 * color.G +
                          0.114 * color.B) / 255.0);

            if (a < 0.5)
            {
                d = 0;                  // bright colors - black font
            }
            else
            {
                d = 255;                // dark colors - white font
            }

            return (Color.FromArgb(d, d, d));
        }

        #endregion

        #region Moving Pen


        // ********************************** create_moving_border_pen

        /// <summary>
        /// creates the pen that will be used to draw the moving
        /// border
        /// </summary>
        void create_moving_border_pen()
        {

            if (moving_border_pen != null)
            {
                moving_border_pen.Dispose();
                moving_border_pen = null;
            }

            moving_border_pen =
                new Pen(contrasting_color(BackColor),
                          PenWidth);

            dash_pattern = new float[]
                                {
                                DashLength / PenWidth,
                                DashLength / PenWidth
                                };

            moving_border_pen.DashPattern = dash_pattern;
            moving_border_pen.DashOffset = 0.0F;
            moving_border_pen.DashStyle = DashStyle.Custom;
            moving_border_pen.EndCap = LineCap.Flat;
            moving_border_pen.StartCap = LineCap.Flat;
        }

        #endregion

        #region Initialize Starts and Ends



        // ******************************** initialize_starts_and_ends

        /// <summary>
        /// performs the initialization of the TOP, RIGHT, BOTTOM, and
        /// LEFT edges starting and ending points; initialization is
        /// performed by the OnPaint event handler when the button's
        /// size is known
        /// </summary>
        void initialize_starts_and_ends()
        {
            // initialization is performed 
            // once during OnPaint when 
            // the button's size is known
            for (int i = 0; (i < EDGES); i++)
            {
                switch (i)
                {
                    case TOP:
                        start_at[TOP] = new Point(
                            -(DashLength - 1),
                            (PenWidth / 2));
                        end_at[TOP] = start_at[TOP];
                        end_at[TOP].X = this.Width +
                                           DashLength;
                        break;
                    case RIGHT:
                        start_at[RIGHT] = new Point(
                            this.Width - (PenWidth / 2) - 1,
                            -(DashLength - 1));
                        end_at[RIGHT] = start_at[RIGHT];
                        end_at[RIGHT].Y = this.Height +
                                             DashLength;
                        break;

                    case BOTTOM:
                        start_at[BOTTOM] = new Point(
                            this.Width + (DashLength - 1),
                            this.Height - (PenWidth / 2) - 1);
                        end_at[BOTTOM] = start_at[BOTTOM];
                        end_at[BOTTOM].X = -DashLength;
                        break;

                    case LEFT:
                        start_at[LEFT] = new Point(
                            (PenWidth / 2),
                            this.Height + (DashLength - 1));
                        end_at[LEFT] = start_at[LEFT];
                        end_at[LEFT].Y = -DashLength;
                        break;

                    default:
                        break;
                }
            }

            initialized = true;
        }
        #endregion

        #region Revise Start Ats


        // ****************************************** revise_start_ats

        /// <summary>
        /// revises the TOP, RIGHT, BOTTOM, and LEFT edges starting
        /// point at each timer tick; revision is performed by the
        /// OnPaint event handler
        /// </summary>
        void revise_start_ats()
        {

            start_at[TOP].X++;
            if (start_at[TOP].X >= DashLength)
            {
                start_at[TOP].X = -(DashLength + 1);
            }

            start_at[RIGHT].Y++;
            if (start_at[RIGHT].Y >= DashLength)
            {
                start_at[RIGHT].Y = -(DashLength - 1);
            }

            start_at[BOTTOM].X--;
            if (start_at[BOTTOM].X <= this.Width - DashLength)
            {
                start_at[BOTTOM].X =
                    this.Width + (DashLength - 1);
            }

            start_at[LEFT].Y--;
            if (start_at[LEFT].Y <= this.Height - DashLength)
            {
                start_at[LEFT].Y =
                    this.Height + (DashLength - 1);
            }
        }
        #endregion

        #region Create Moving Border Graphic
        // ***************************** create_moving_border_graphic

        /// <summary>
        /// creates the graphic image of the moving border that will be
        /// rendered on the button's surface
        /// </summary>

        void create_moving_border_graphic()
        {
            // delete existing buffer
            if (moving_border_graphic != null)
            {
                moving_border_graphic = moving_border_graphic.
                                       DeleteGraphicsBuffer();
            }
            // create a new buffer
            moving_border_graphic = new GraphicsBuffer();
            moving_border_graphic.InitializeGraphicsBuffer(
                                                      "Moving",
                                                      this.Width,
                                                      this.Height);
            moving_border_graphic.Graphic.SmoothingMode =
                SmoothingMode.HighQuality;
            // draw the border edges
            for (int i = 0; (i < EDGES); i++)
            {
                moving_border_graphic.Graphic.DrawLine(
                    moving_border_pen,
                    start_at[i],
                    end_at[i]);
            }
        }

        #endregion

        #region Constructor


        // ***************************************** MovingBorderButton

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMoveBorderButton" /> class.
        /// </summary>
        public ZeroitMoveBorderButton()
        {

            this.SetStyle((ControlStyles.DoubleBuffer |
                              ControlStyles.UserPaint |
                              ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw),
                            true);
            this.UpdateStyles();

            this.Disposed += new EventHandler(memory_cleanup);

            IncludeInConstructor();
        }

        // ****************************************************** tick

        /// <summary>
        /// handles the timer's elapsed time event
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        /// <note>
        /// this event handler executes in a thread separate from the
        /// user interface thread and therefore needs to use Invoke
        /// </note>
        void tick(object source,
                    ElapsedEventArgs e)
        {

            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(
                        new EventHandler(
                            delegate
                            {
                                this.Refresh();
                            }
                            )
                        );
                }
                else
                {
                    this.Refresh();
                }
            }
            catch
            {

            }
        }

        #endregion

        #region DashLength


        // ************************************************ DashLength

        /// <summary>
        /// Gets or sets the length of the dash.
        /// </summary>
        /// <value>The length of the dash.</value>
        [Category("Appearance"),
          Description("Sets/Gets length of the button border dashes"),
          DefaultValue(typeof(int), "6"),
          Bindable(true)]
        public int DashLength
        {

            get
            {
                return (dash_length);
            }

            set
            {
                if (dash_length != value)
                {
                    if (value > PenWidth)
                    {
                        dash_length = value;
                        create_moving_border_pen();
                        this.Invalidate();
                    }
                }
            }
        }

        #endregion

        #region Move Button Border

        // ****************************************** MoveButtonBorder        
        /// <summary>
        /// Gets or sets a value indicating whether to move the button border.
        /// </summary>
        /// <value><c>true</c> if move button border; otherwise, <c>false</c>.</value>
        [Category("Appearance"),
          Description("Specifies if button border should move"),
          DefaultValue(typeof(bool), "false"),
          Bindable(true)]
        public bool MoveButtonBorder
        {

            get
            {
                return (move_button_border);
            }

            set
            {
                move_button_border = value;
                if (move_button_border)
                {
                    // prevent button from drawing 
                    // its own border
                    FlatAppearance.BorderSize = 0;
                    FlatStyle = FlatStyle.Flat;

                    if (timer == null)
                    {
                        timer = new System.Timers.Timer();
                        timer.Elapsed +=
                            new ElapsedEventHandler(tick);
                        timer.Interval = timer_interval;
                        timer.Start();
                    }
                }
                else
                {
                    if (timer != null)
                    {
                        if (timer.Enabled)
                        {
                            timer.Elapsed -=
                                new ElapsedEventHandler(tick);
                            timer.Stop();
                        }
                        timer = null;
                    }
                    // allow button to draw its 
                    // own border
                    FlatAppearance.BorderSize = 1;
                    FlatStyle = FlatStyle.Standard;
                }

                Invalidate();
            }
        }
        #endregion

        #region Pen Width

        // ************************************************** PenWidth        
        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        [Category("Appearance"),
          Description("Sets/Gets width of the button border pen"),
          DefaultValue(typeof(int), "2"),
          Bindable(true)]
        public int PenWidth
        {

            get
            {
                return (pen_width);
            }

            set
            {
                if (pen_width != value)
                {
                    if ((value > 0) &&
                         (value < DashLength))
                    {
                        pen_width = value;
                        create_moving_border_pen();
                        this.Invalidate();
                    }
                }
            }
        }

        #endregion

        #region Timer Interval


        // ********************************************* TimerInterval

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        [Category("Appearance"),
          Description("Sets/Gets how often button border moves (ms)"),
          DefaultValue(typeof(double), "20.0"),
          Bindable(true)]
        public double TimerInterval
        {

            get
            {
                return (timer_interval);
            }

            set
            {
                timer_interval = value;
                if (timer != null)
                {
                    if (timer.Enabled)
                    {
                        timer.Elapsed -=
                            new ElapsedEventHandler(tick);
                        timer.Stop();
                    }
                    timer = new System.Timers.Timer();
                    timer.Elapsed +=
                        new ElapsedEventHandler(tick);
                    timer.Interval = timer_interval;
                    timer.Start();
                }
            }
        }
        #endregion

        #region OnPaint


        // *************************************************** OnPaint

        /// <summary>
        /// the Paint event handler
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        /// <note>
        /// the button is drawn in the usual manner by the base
        /// method; then a border is added if MoveButtonBorder is
        /// true; note too that MoveButtonBorder makes appropriate
        /// changes to FlatAppearance and FlatStyle
        /// </note>
        protected override void OnPaint(PaintEventArgs e)
        {
            // have base class paint the 
            // button normally
            base.OnPaint(e);

            
            // add the moving border only 
            // if border movement was 
            // specified
            if (MoveButtonBorder)
            {
                TransparentInPaint(e.Graphics);
                if (!initialized)
                {
                    initialize_starts_and_ends();
                    create_moving_border_pen();
                }

                create_moving_border_graphic();
                moving_border_graphic.RenderGraphicsBuffer(
                                        e.Graphics);
                revise_start_ats();

                
            }
            

            
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

    } // class MovingBorderButton

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitButtonMovingBorderButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonMovingBorderButtonDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitButtonMovingBorderSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitButtonMovingBorderSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitButtonMovingBorderSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMoveBorderButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonMovingBorderSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitButtonMovingBorderSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMoveBorderButton;

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
        /// Gets or sets the length of the dash.
        /// </summary>
        /// <value>The length of the dash.</value>
        public int DashLength
        {

            get
            {
                return colUserControl.DashLength;
            }
            set
            {
                GetPropertyByName("DashLength").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [move button border].
        /// </summary>
        /// <value><c>true</c> if [move button border]; otherwise, <c>false</c>.</value>
        public bool MoveButtonBorder
        {

            get
            {
                return colUserControl.MoveButtonBorder;
            }
            set
            {
                GetPropertyByName("MoveButtonBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the pen.
        /// </summary>
        /// <value>The width of the pen.</value>
        public int PenWidth
        {

            get
            {
                return colUserControl.PenWidth;
            }
            set
            {
                GetPropertyByName("PenWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public double TimerInterval
        {

            get
            {
                return colUserControl.TimerInterval;
            }
            set
            {
                GetPropertyByName("TimerInterval").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("DashLength",
                                 "Dash Length", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("MoveButtonBorder",
                                 "Move Button Border", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("PenWidth",
                                 "Pen Width", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("TimerInterval",
                                 "Timer Interval", "Appearance",
                                 "Type few characters to filter Cities."));

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
