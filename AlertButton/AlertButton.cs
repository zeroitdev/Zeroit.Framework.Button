// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="AlertButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{
    #region ZeroitButtonAlert
    /// <summary>
    /// A class collection for rendering an alert button control
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitButtonAlertDesigner))]
    public class ZeroitAlertButton : Control
    {

        #region Image Designer

        #region Include in paint method

        /////////////////////////////////////////////////////////////////////////////////////////////////// 
        // ------------------------Add this to the Paint Method ------------------------       Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   if ((Image == null))                                                                        {                                                                                       _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           {                                                                               Alignment = _TextAlignment,                                                 LineAlignment = StringAlignment.Center                                      });                                                                             }                                                                                      else                                                                                        {                                                                                      _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          {                                                                               Alignment = _TextAlignment,                                                 LineAlignment = StringAlignment.Center                                      });                                                                             }
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        #endregion

        #region Include in Private Fields
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

        #endregion

        #region Include in Public Properties
        /// <summary>
        /// Property to get and set Image
        /// </summary>
        /// <value>Gets and sets the Image</value>
        /// <remarks>This will be used in setting the image to be used for the control</remarks>
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
        /// Set Image Size
        /// </summary>
        /// <value>Gets and sets the Image Size.</value>
        /// <remarks>This will be used in either expanding or reducing the image</remarks>
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
        /// Set Image Alignment
        /// </summary>
        /// <value>Gets and sets the image alignment</value>
        /// <remarks>This sets the image to be aligned either to the left, center or right.</remarks>
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


        #region " Drawing "

        /// <summary>
        /// The g
        /// </summary>
        private Graphics G;

        /// <summary>
        /// The alert
        /// </summary>
        private Style _Alert;

        /// <summary>
        /// Get and set to enable text to be centered.
        /// </summary>
        /// <value><c>true</c> if centered; otherwise, <c>false</c>.</value>
        public bool Centered { get; set; }
        /// <summary>
        /// Get and set to enable triangular field drawn.
        /// </summary>
        /// <value><c>true</c> if field; otherwise, <c>false</c>.</value>
        public bool Field { get; set; }

        /// <summary>
        /// Sets the Style of the alert button.
        /// </summary>
        /// <remarks>This is an enumeration for getting the state of the button.</remarks>
        public enum Style : byte
        {
            /// <summary>
            /// Sets the Style to Notice
            /// </summary>
            Notice = 0,

            /// <summary>
            /// Sets the Style to Informations
            /// </summary>
            Informations = 1,

            /// <summary>
            /// Sets the Style to Warning
            /// </summary>
            Warning = 2,

            /// <summary>
            /// Sets the Style to Success
            /// </summary>
            Success = 3
        }

        /// <summary>
        /// Property to alert the user
        /// </summary>
        /// <value>The alert.</value>
        /// <remarks>This property alerts the user with a warning, a success, a notice or just an info.</remarks>
        public Style Alert
        {
            get { return _Alert; }
            set
            {
                _Alert = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Creates an instance of the alert button
        /// </summary>
        public ZeroitAlertButton()
        {
            DoubleBuffered = true;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Parent.BackColor);

            Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          ///
                                                                                                        ///
            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   ///
                                                                                                        ///


            switch (Alert)
            {

                case Style.Notice:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(217, 237, 247));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(188, 232, 241));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(188, 232, 241));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(217, 237, 247));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(58, 135, 173), new Rectangle(20, 0, Width, Height));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(58, 135, 173)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

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

                    }
                    else
                    {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(217, 237, 247));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(188, 232, 241));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(58, 135, 173), Helpers.FullRectangle(Size, false));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(58, 135, 173)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }

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
                    }

                    break;

                case Style.Informations:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(252, 248, 227));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(251, 238, 213));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(251, 238, 213));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(252, 248, 227));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(192, 152, 83), new Rectangle(20, 0, Width, Height));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(192, 152, 83)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

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

                    }
                    else
                    {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(252, 248, 227));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(251, 238, 213));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(192, 152, 83), Helpers.FullRectangle(Size, false));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(192, 152, 83)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }

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
                    }

                    break;
                case Style.Warning:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(242, 222, 222));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(238, 211, 215));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(238, 211, 215));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(242, 222, 222));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(185, 74, 72), new Rectangle(20, 0, Width, Height));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(185, 74, 72)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

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

                    }
                    else
                    {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(242, 222, 222));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(238, 211, 215));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(185, 74, 72), Helpers.FullRectangle(Size, false));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(185, 74, 72)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }

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
                    }

                    break;
                default:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(223, 240, 216));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(214, 233, 198));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(214, 233, 198));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(223, 240, 216));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(70, 136, 71), new Rectangle(20, 0, Width, Height));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(70, 136, 71)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

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

                    }
                    else
                    {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(223, 240, 216));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(214, 233, 198));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(70, 136, 71), Helpers.FullRectangle(Size, false));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(70, 136, 71)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }

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
                    }
                    break;
            }

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!Field)
            {
                Height = 37;
            }
        }

        #endregion

    }



    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitButtonAlertDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    class ZeroitButtonAlertDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitButtonAlertSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitButtonAlertSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    class ZeroitButtonAlertSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitAlertButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonAlertSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitButtonAlertSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitAlertButton;

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
        /// Gets or sets the alert.
        /// </summary>
        /// <value>The alert.</value>
        public Zeroit.Framework.Button.ZeroitAlertButton.Style Alert
        {
            get
            {
                return colUserControl.Alert;
            }
            set
            {
                GetPropertyByName("Alert").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return colUserControl.Text;
            }
            set
            {
                GetPropertyByName("Text").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Alert",
                                 "Alert", "Appearance",
                                 "Set the alert type."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Set the text of the control."));

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
