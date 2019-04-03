// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="AwesomeButton.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{
    #region ZeroitButtonAwesome

    /// <summary>
    /// A class collection for rendering an Awesome button control
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Button.ThemeControl" />
    [Designer(typeof(ZeroitButtonAwesomeDesigner))]
    public class ZeroitAwesomeButton : ThemeControl
    {
        #region Variables
        /// <summary>
        /// The color1 inactive
        /// </summary>
        private Color color1_inactive = Color.FromArgb(51, 159, 231);
        /// <summary>
        /// The color2 inactive
        /// </summary>
        private Color color2_inactive = Color.FromArgb(33, 128, 206);
        /// <summary>
        /// The color1 pressed
        /// </summary>
        private Color color1_pressed = Color.FromArgb(37, 124, 196);
        /// <summary>
        /// The color2 pressed
        /// </summary>
        private Color color2_pressed = Color.FromArgb(53, 153, 219);
        /// <summary>
        /// The color1 hover
        /// </summary>
        private Color color1_hover = Color.FromArgb(54, 167, 243);
        /// <summary>
        /// The color2 hover
        /// </summary>
        private Color color2_hover = Color.FromArgb(35, 165, 217);
        /// <summary>
        /// The color text inactive
        /// </summary>
        private Color color_textInactive = Color.FromArgb(240, 240, 240);
        /// <summary>
        /// The color text pressed
        /// </summary>
        private Color color_textPressed = Color.FromArgb(250, 250, 250);
        /// <summary>
        /// The color text hover
        /// </summary>
        private Color color_textHover = Color.FromArgb(240, 240, 240);
        /// <summary>
        /// The color line
        /// </summary>
        private Color color_Line = Color.FromArgb(131, 197, 241);
        /// <summary>
        /// The color line hover
        /// </summary>
        private Color color_Line_Hover = Color.FromArgb(131, 197, 241);
        /// <summary>
        /// The color pen
        /// </summary>
        private Color color_Pen = Color.FromArgb(34, 112, 171);
        /// <summary>
        /// The color pen pressed
        /// </summary>
        private Color color_Pen_Pressed = Color.FromArgb(34, 112, 171);
        /// <summary>
        /// The color pen hover
        /// </summary>
        private Color color_Pen_Hover = Color.FromArgb(34, 112, 171);

        /// <summary>
        /// The text align
        /// </summary>
        HorizontalAlignment textAlign = HorizontalAlignment.Center;

        #endregion


        #region Image Designer

        #region Include in paint method

        /////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// The image
        /// </summary>
        /// ------------------------Add this to the Paint Method ------------------------       Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   if ((Image == null))                                                                        {                                                                                       _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           {                                                                               Alignment = _TextAlignment,                                                 LineAlignment = StringAlignment.Center                                      });                                                                             }                                                                                      else                                                                                        {                                                                                      _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          {                                                                               Alignment = _TextAlignment,                                                 LineAlignment = StringAlignment.Center                                      });                                                                             }
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        #endregion

        #region Include in Private Fields
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

        #endregion

        #region Include in Public Properties
        /// <summary>
        /// Gets or sets the image.
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
        /// Gets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        protected Size ImageSize
        {
            get { return _ImageSize; }
        }

        /// <summary>
        /// Gets or sets the image align.
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


        #region Properties

        /// <summary>
        /// Property for Text Alignment
        /// </summary>
        /// <value>Gets and sets the text alignment</value>
        /// <remarks>This sets the text alignment to either left, center or right</remarks>
        public HorizontalAlignment TextAlign
        {
            get { return textAlign; }
            set
            {
                textAlign = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Property for Color
        /// </summary>
        /// <value>Gets and sets the inactive color</value>
        /// <remarks>This sets the Inactive color 1</remarks>
        public Color Color1_inactive
        {
            get { return color1_inactive; }
            set
            {
                color1_inactive = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Color
        /// </summary>
        /// <value>Gets and sets the inactive color</value>
        /// <remarks>This sets the Inactive color 2</remarks>
        public Color Color2_inactive
        {
            get { return color2_inactive; }
            set
            {
                color2_inactive = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Color
        /// </summary>
        /// <value>Gets and sets the pressed color</value>
        /// <remarks>This sets the Pressed color 1</remarks>
        public Color Color1_pressed
        {
            get { return color1_pressed; }
            set
            {
                color1_pressed = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Color
        /// </summary>
        /// <value>Gets and sets the pressed color</value>
        /// <remarks>This sets the Pressed color 2</remarks>
        public Color Color2_pressed
        {
            get { return color2_pressed; }
            set
            {
                color2_pressed = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Color
        /// </summary>
        /// <value>Gets and sets the hover color</value>
        /// <remarks>This sets the Hover color 1</remarks>
        public Color Color1_hover
        {
            get { return color1_hover; }
            set
            {
                color1_hover = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Color
        /// </summary>
        /// <value>Gets and sets the hover color</value>
        /// <remarks>This sets the Hover color 2</remarks>
        public Color Color2_hover
        {
            get { return color2_hover; }
            set
            {
                color2_hover = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Text Color
        /// </summary>
        /// <value>Gets and sets the inactive text color</value>
        /// <remarks>This sets the Inactive Text color</remarks>
        public Color Color_TextInactive
        {
            get { return color_textInactive; }
            set
            {
                color_textInactive = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Text Color
        /// </summary>
        /// <value>Gets and sets the pressed text color</value>
        /// <remarks>This sets the Pressed Text color</remarks>
        public Color Color_TextPressed
        {
            get { return color_textPressed; }
            set
            {
                color_textPressed = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Text Color
        /// </summary>
        /// <value>Gets and sets the hover text color</value>
        /// <remarks>This sets the Hover Text color</remarks>
        public Color Color_TextHover
        {
            get { return color_textHover; }
            set
            {
                color_textHover = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Line Color
        /// </summary>
        /// <value>Gets and sets the line color</value>
        /// <remarks>This sets the Line color</remarks>
        public Color Color_Line
        {
            get { return color_Line; }
            set
            {
                color_Line = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Line Color
        /// </summary>
        /// <value>Gets and sets the hover line color</value>
        /// <remarks>This sets the Line Hover color</remarks>
        public Color Color_Line_Hover
        {
            get { return color_Line_Hover; }
            set
            {
                color_Line_Hover = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Pen Color
        /// </summary>
        /// <value>Gets and sets the inactive pen color</value>
        /// <remarks>This sets the Pen Inactive color</remarks>
        public Color Color_Pen_Inactive
        {
            get { return color_Pen; }
            set
            {
                color_Pen = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Pen Color
        /// </summary>
        /// <value>Gets and sets the pressed pen color</value>
        /// <remarks>This sets the Pen Pressed color</remarks>
        public Color Color_Pen_Pressed
        {
            get { return color_Pen_Pressed; }
            set
            {
                color_Pen_Pressed = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Property for Pen Color
        /// </summary>
        /// <value>Gets and sets the hover pen color</value>
        /// <remarks>This sets the Pen Hover color</remarks>
        public Color Color_Pen_Hover
        {
            get { return color_Pen_Hover; }
            set
            {
                color_Pen_Hover = value;
                this.Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Creates an instance of the Awesome Button class
        /// </summary>
        public ZeroitAwesomeButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            IncludeInConstructor();

        }

        /// <summary>
        /// Paints the hook.
        /// </summary>
        public override void PaintHook()
        {
            this.Font = new Font("Arial", 10);
            G.Clear(this.BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          ///
                                                                                                        ///
            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   ///
                                                                                                        ///


            switch (MouseState)
            {
                case State.MouseNone:
                    Pen p = new Pen(color_Pen, 1);
                    LinearGradientBrush x = new LinearGradientBrush(ClientRectangle, color1_inactive, color2_inactive, LinearGradientMode.Vertical);
                    G.FillPath(x, Draw.RoundRect(ClientRectangle, 4));
                    G.DrawPath(p, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 3));
                    G.DrawLine(new Pen(color_Line), 2, 1, Width - 3, 1);
                    DrawText(textAlign, color_textInactive, 0);

                    if ((Image == null))                                                                        ///

                    {                                                                                       ///
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           ///

                        //{                                                                               ///
                        //    Alignment = _TextAlignment,                                                 ///
                        //    LineAlignment = StringAlignment.Center                                      ///

                        //});                                                                             ///

                    }                                                                                      ///

                    else                                                                                        ///

                    {                                                                                      ///
                        G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              ///
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          ///

                        //{                                                                               ///
                        //    Alignment = _TextAlignment,                                                 ///
                        //    LineAlignment = StringAlignment.Center                                      ///

                        //});                                                                             ///

                    }

                    break;
                case State.MouseDown:
                    p = new Pen(color_Pen_Pressed, 1);
                    x = new LinearGradientBrush(ClientRectangle, color1_pressed, color2_pressed, LinearGradientMode.Vertical);
                    G.FillPath(x, Draw.RoundRect(ClientRectangle, 4));
                    G.DrawPath(p, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 3));

                    DrawText(textAlign, color_textPressed, 1);

                    if ((Image == null))                                                                        ///

                    {                                                                                       ///
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           ///

                        //{                                                                               ///
                        //    Alignment = _TextAlignment,                                                 ///
                        //    LineAlignment = StringAlignment.Center                                      ///

                        //});                                                                             ///

                    }                                                                                      ///

                    else                                                                                        ///

                    {                                                                                      ///
                        G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              ///
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          ///

                        //{                                                                               ///
                        //    Alignment = _TextAlignment,                                                 ///
                        //    LineAlignment = StringAlignment.Center                                      ///

                        //});                                                                             ///

                    }

                    break;
                case State.MouseOver:
                    p = new Pen(color_Pen_Hover, 1);
                    x = new LinearGradientBrush(ClientRectangle, color1_hover, color2_hover, LinearGradientMode.Vertical);
                    G.FillPath(x, Draw.RoundRect(ClientRectangle, 4));
                    G.DrawPath(p, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 3));
                    G.DrawLine(new Pen(color_Line_Hover), 2, 1, Width - 3, 1);
                    DrawText(textAlign, color_textHover, -1);

                    if ((Image == null))                                                                        ///

                    {                                                                                       ///
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           ///

                        //{                                                                               ///
                        //    Alignment = _TextAlignment,                                                 ///
                        //    LineAlignment = StringAlignment.Center                                      ///

                        //});                                                                             ///

                    }                                                                                      ///

                    else                                                                                        ///

                    {                                                                                      ///
                        G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              ///
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          ///

                        //{                                                                               ///
                        //    Alignment = _TextAlignment,                                                 ///
                        //    LineAlignment = StringAlignment.Center                                      ///

                        //});                                                                             ///

                    }
                    break;
            }
            this.Cursor = Cursors.Hand;
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


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitButtonAwesomeDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    class ZeroitButtonAwesomeDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitButtonAwesomeSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitButtonAwesomeSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    class ZeroitButtonAwesomeSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitAwesomeButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonAwesomeSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitButtonAwesomeSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitAwesomeButton;

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
        /// Gets or sets the color text inactive.
        /// </summary>
        /// <value>The color text inactive.</value>
        public Color Color_TextInactive
        {
            get
            {
                return colUserControl.Color_TextInactive;
            }
            set
            {
                GetPropertyByName("Color_TextInactive").SetValue(colUserControl, value);
            }
        }

        //where Color1_inactive property exist. Replace with an existing property
        /// <summary>
        /// Gets or sets the color1 inactive.
        /// </summary>
        /// <value>The color1 inactive.</value>
        public Color Color1_inactive
        {
            get { return colUserControl.Color1_inactive; }
            set
            {
                GetPropertyByName("Color1_inactive").SetValue(colUserControl, value);
            }
        }

        //where Color2_inactive property exist. Replace with an existing property
        /// <summary>
        /// Gets or sets the color2 inactive.
        /// </summary>
        /// <value>The color2 inactive.</value>
        public Color Color2_inactive
        {
            get { return colUserControl.Color2_inactive; }
            set
            {
                GetPropertyByName("Color2_inactive").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color1 pressed.
        /// </summary>
        /// <value>The color1 pressed.</value>
        public Color Color1_pressed
        {
            get { return colUserControl.Color1_pressed; }
            set
            {
                GetPropertyByName("Color1_pressed").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color2 pressed.
        /// </summary>
        /// <value>The color2 pressed.</value>
        public Color Color2_pressed
        {
            get { return colUserControl.Color2_pressed; }
            set
            {
                GetPropertyByName("Color2_pressed").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color1 hover.
        /// </summary>
        /// <value>The color1 hover.</value>
        public Color Color1_hover
        {
            get { return colUserControl.Color1_hover; }
            set
            {
                GetPropertyByName("Color1_hover").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color2 hover.
        /// </summary>
        /// <value>The color2 hover.</value>
        public Color Color2_hover
        {
            get { return colUserControl.Color2_hover; }
            set
            {
                GetPropertyByName("Color2_hover").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color line.
        /// </summary>
        /// <value>The color line.</value>
        public Color Color_Line
        {
            get { return colUserControl.Color_Line; }
            set
            {
                GetPropertyByName("Color_Line").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color line hover.
        /// </summary>
        /// <value>The color line hover.</value>
        public Color Color_Line_Hover
        {
            get { return colUserControl.Color_Line_Hover; }
            set
            {
                GetPropertyByName("Color_Line_Hover").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color pen inactive.
        /// </summary>
        /// <value>The color pen inactive.</value>
        public Color Color_Pen_Inactive
        {
            get { return colUserControl.Color_Pen_Inactive; }
            set
            {
                GetPropertyByName("Color_Pen_Inactive").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color pen pressed.
        /// </summary>
        /// <value>The color pen pressed.</value>
        public Color Color_Pen_Pressed
        {
            get { return colUserControl.Color_Pen_Pressed; }
            set
            {
                GetPropertyByName("Color_Pen_Pressed").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color pen hover.
        /// </summary>
        /// <value>The color pen hover.</value>
        public Color Color_Pen_Hover
        {
            get { return colUserControl.Color_Pen_Hover; }
            set
            {
                GetPropertyByName("Color_Pen_Hover").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Color1_inactive",
                                 "Color1 inactive", "Appearance",
                                 "Sets the Background color when inactive."));

            items.Add(new DesignerActionPropertyItem("Color2_inactive",
                                 "Color2 inactive", "Appearance",
                                 "Sets the Background color when inactive."));

            items.Add(new DesignerActionPropertyItem("Color1_pressed",
                                 "Color1 pressed", "Appearance",
                                 "Sets the Background color when pressed."));

            items.Add(new DesignerActionPropertyItem("Color2_pressed",
                                 "Color2 pressed", "Appearance",
                                 "Sets the Background color when pressed."));

            items.Add(new DesignerActionPropertyItem("Color1_hover",
                                 "Color1 hover", "Appearance",
                                 "Sets the Background color when hovered."));

            items.Add(new DesignerActionPropertyItem("Color2_hover",
                                 "Color2 hover", "Appearance",
                                 "Sets the Background color when hovered."));

            items.Add(new DesignerActionPropertyItem("Color_TextInactive",
                                 "Color TextInactive", "Appearance",
                                 "Sets the Fore color of the button."));

            items.Add(new DesignerActionPropertyItem("Color_Line",
                                 "Color Line", "Appearance",
                                 "Sets the Line color of the button."));

            items.Add(new DesignerActionPropertyItem("Color_Line_Hover",
                                 "Color Line Hover", "Appearance",
                                 "Sets the Line color of the button when hovered."));

            items.Add(new DesignerActionPropertyItem("Color_Pen_Inactive",
                                 "Color Pen Inactive", "Appearance",
                                 "Sets the Pen color of the button."));

            items.Add(new DesignerActionPropertyItem("Color_Pen_Pressed",
                                 "Color Pen Pressed", "Appearance",
                                 "Sets the Pen color of the button when pressed."));

            items.Add(new DesignerActionPropertyItem("Color_Pen_Hover",
                                 "Color Pen Hover", "Appearance",
                                 "Sets the Pen color of the button when hovered."));

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
