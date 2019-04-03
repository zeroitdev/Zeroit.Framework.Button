// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ShapeControlDialog.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Button.Editor
{

    /// <summary>
    /// Class ShapeControlDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ShapeControlDialog : System.Windows.Forms.Form
    {

        #region Constructor


        /// <summary>
        /// Initializes a new instance of <c>FillerEditorDialog</c> using an empty <c>Filler</c>
        /// at the default window position.
        /// </summary>
        public ShapeControlDialog() : this(ShapeInput.Empty())
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>FillerEditorDialog</c> using an existing <c>Filler</c>
        /// at the default window position.
        /// </summary>
        /// <param name="shapePopulate">Existing <c>Filler</c> object.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="filler" /> is null.</exception>
        public ShapeControlDialog(ShapeInput shapePopulate)
        {
            if (shapePopulate == null)
            {
                throw new ArgumentNullException("shapePopulate");
            }


            InitializeComponent();
            //FillGradientComboBox();
            AdjustDialogSize();
            //Set_Rectangle_InitialValues();
            //SetControls_Circle_To_Initial_Values(shapePopulate);
            SetControl_Initial_Values(shapePopulate);
            //SetControls_Polygon_To_Initial_Values(shapePopulate);
            //SetControls_Pie_To_Initial_Values(shapePopulate);

        }


        /// <summary>
        /// Initializes a new instance of <c>FillerEditorDialog</c> using an empty <c>Filler</c>
        /// and positioned beneath the specified control.
        /// </summary>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
        public ShapeControlDialog(Control c) : this(ShapeInput.Empty(), c)
        {
        }

        /// <summary>
        /// Initializes a new instance of <c>FillerEditorDialog</c> using an existing <c>Filler</c>
        /// and positioned beneath the specified control.
        /// </summary>
        /// <param name="shapePopulate">The shape populate.</param>
        /// <param name="c">Control beneath which the dialog should be placed.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="filler" /> is null.</exception>
        public ShapeControlDialog(ShapeInput shapePopulate, Control c) : this(shapePopulate)
        {
            Zeroit.Framework.Button.Helper.Draw.SetStartPositionBelowControl(this, c);
        }


        #endregion

        #region Fields

        /// <summary>
        /// The no
        /// </summary>
        private const int No = 0;
        /// <summary>
        /// The yes
        /// </summary>
        private const int Yes = 1;
        /// <summary>
        /// The shape populate
        /// </summary>
        private ShapeInput shapePopulate;

        #region Rectangle Parameters

        /// <summary>
        /// The rectangle rounding retrieved
        /// </summary>
        public static string rectangleRounding_Retrieved = "Yes";
        /// <summary>
        /// The rectangle border retrieved
        /// </summary>
        public static string rectangleBorder_Retrieved = "Yes";
        /// <summary>
        /// The rectangle colored retrieved
        /// </summary>
        public static string rectangleColored_Retrieved = "Yes";

        /// <summary>
        /// The rectangle curve retrieved
        /// </summary>
        public int rectangleCurve_Retrieved = 10;
        /// <summary>
        /// The rectangle border width retrieved
        /// </summary>
        public static int rectangleBorderWidth_Retrieved = 2;
        /// <summary>
        /// The rectangle color retrieved
        /// </summary>
        public static Color rectangleColor_Retrieved = Color.Yellow;
        /// <summary>
        /// The rectangle border color retrieved
        /// </summary>
        public static Color rectangleBorderColor_Retrieved = Color.DeepSkyBlue;

        /// <summary>
        /// The rectangle curve ul retrieved
        /// </summary>
        public int rectangleCurve_UL_Retrieved = 40;
        /// <summary>
        /// The rectangle curve ur retrieved
        /// </summary>
        public int rectangleCurve_UR_Retrieved = 40;
        /// <summary>
        /// The rectangle curve dl retrieved
        /// </summary>
        public int rectangleCurve_DL_Retrieved = 40;
        /// <summary>
        /// The rectangle curve dr retrieved
        /// </summary>
        public int rectangleCurve_DR_Retrieved = 40;

        #endregion

        #region Circle Parameters

        /// <summary>
        /// The circle border retrieved
        /// </summary>
        public string circleBorder_Retrieved = "Yes";
        /// <summary>
        /// The circle colored retrieved
        /// </summary>
        public string circleColored_Retrieved = "Yes";

        /// <summary>
        /// The circle border width retrieved
        /// </summary>
        public int circleBorderWidth_Retrieved = 2;
        /// <summary>
        /// The circle color retrieved
        /// </summary>
        public Color circleColor_Retrieved = Color.Yellow;
        /// <summary>
        /// The circle border color retrieved
        /// </summary>
        public Color circleBorderColor_Retrieved = Color.DeepSkyBlue;


        #endregion

        #region Polygon Parameters


        /// <summary>
        /// The polygon border retrieved
        /// </summary>
        public string polygonBorder_Retrieved = "Yes";
        /// <summary>
        /// The polygon colored retrieved
        /// </summary>
        public string polygonColored_Retrieved = "Yes";


        /// <summary>
        /// The polygon border width retrieved
        /// </summary>
        public int polygonBorderWidth_Retrieved = 2;
        /// <summary>
        /// The polygon color retrieved
        /// </summary>
        public Color polygonColor_Retrieved = Color.Yellow;
        /// <summary>
        /// The polygon border color retrieved
        /// </summary>
        public Color polygonBorderColor_Retrieved = Color.DeepSkyBlue;

        /// <summary>
        /// The polygon sides retrieved
        /// </summary>
        public int polygonSides_Retrieved = 3;
        /// <summary>
        /// The polygon angle retrieved
        /// </summary>
        public int polygonAngle_Retrieved = 90;

        #endregion

        #region Pie Parameters

        /// <summary>
        /// The pie rounding retrieved
        /// </summary>
        public string pieRounding_Retrieved = "Yes";
        /// <summary>
        /// The pie border retrieved
        /// </summary>
        public string pieBorder_Retrieved = "Yes";
        /// <summary>
        /// The pie colored retrieved
        /// </summary>
        public string pieColored_Retrieved = "Yes";


        /// <summary>
        /// The pie border width retrieved
        /// </summary>
        public int pieBorderWidth_Retrieved = 2;
        /// <summary>
        /// The pie color retrieved
        /// </summary>
        public Color pieColor_Retrieved = Color.Yellow;
        /// <summary>
        /// The pie border color retrieved
        /// </summary>
        public Color pieBorderColor_Retrieved = Color.DeepSkyBlue;
        /// <summary>
        /// The pie start angle retrieved
        /// </summary>
        public float pie_StartAngle_Retrieved = 0;
        /// <summary>
        /// The pie end angle retrieved
        /// </summary>
        public float pie_EndAngle_Retrieved = 90;


        #endregion


        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the shape input.
        /// </summary>
        /// <value>The shape input.</value>
        public ShapeInput ShapeInput
        {
            get { return shapePopulate; }
        }

        /// <summary>
        /// Gets or sets the ul retrieved.
        /// </summary>
        /// <value>The ul retrieved.</value>
        public int UL_Retrieved
        {
            get { return rectangleCurve_UL_Retrieved; }
            set
            {
                rectangleCurve_UL_Retrieved = value;
                Invalidate();
            }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Adjusts the size of the dialog.
        /// </summary>
        private void AdjustDialogSize()
        {
            // Three different possible group boxes - move them all to one coordinate
            int x = rectangle_GroupBox.Location.X;
            int y = controlTypeContainer.Location.Y;

            rectangle_GroupBox.Location = new Point(x, y);
            circle_GroupBox.Location = new Point(x, y);
            polygon_GroupBox.Location = new Point(x, y);
            pie_GroupBox.Location = new Point(x, y);
            //formName.Location = new Point(typeGroupBox.Location.X, formName.Location.Y - 5);

            int bottomY = Math.Max(rectangle_GroupBox.Bounds.Bottom,
                Math.Max(circle_GroupBox.Bounds.Bottom, 
                Math.Max(polygon_GroupBox.Bounds.Bottom, 
                Math.Max(pie_GroupBox.Bounds.Bottom,
                    controlTypeContainer.Bounds.Bottom))));



            int newHeight = bottomY + controlTypeContainer.Location.Y;

            this.Size = new Size(Size.Width, Size.Height - (ClientSize.Height - newHeight));
        }

        /// <summary>
        /// Sets the control initial values.
        /// </summary>
        /// <param name="shapePopulate">The shape populate.</param>
        private void SetControl_Initial_Values(ShapeInput shapePopulate)
        {

            if (shapePopulate.Rounding)
            {
                rectangle_Rounding_Combo.SelectedIndex = Yes;
                rectangleShape.Rounding = true;
            }
            else
            {
                rectangle_Rounding_Combo.SelectedIndex = No;
                rectangleShape.Rounding = false;
            }

            if (shapePopulate.DrawBorder)
            {
                rectangle_Border_Combo.SelectedIndex = Yes;
                circle_Border_Combo.SelectedIndex = Yes;
                pie_Border_Combo.SelectedIndex = Yes;
                polygon_Border_Combo.SelectedIndex = Yes;
            }
            else
            {
                rectangle_Border_Combo.SelectedIndex = No;
                circle_Border_Combo.SelectedIndex = No;
                pie_Border_Combo.SelectedIndex = No;
                polygon_Border_Combo.SelectedIndex = No;
            }

            if (shapePopulate.ColorShape)
            {
                rectangle_Colored_Combo.SelectedIndex = Yes;
                circle_Colored_Combo.SelectedIndex = Yes;
                pie_Colored_Combo.SelectedIndex = Yes;
                polygon_Colored_Combo.SelectedIndex = Yes;
            }
            else
            {
                rectangle_Colored_Combo.SelectedIndex = No;
                circle_Colored_Combo.SelectedIndex = No;
                pie_Colored_Combo.SelectedIndex = No;
                polygon_Colored_Combo.SelectedIndex = No;
            }



            rectangleCurve_UL_Retrieved = shapePopulate.UpperLeftCurve / 4;
            rectangleCurve_UR_Retrieved = shapePopulate.UpperRightCurve / 4;
            rectangleCurve_DL_Retrieved = shapePopulate.DownLeftCurve / 4;
            rectangleCurve_DR_Retrieved = shapePopulate.DownRightCurve / 4;

            rectangle_Border_UL.Text = rectangleCurve_UL_Retrieved.ToString();
            rectangle_Border_UR.Text = rectangleCurve_UR_Retrieved.ToString();
            rectangle_Border_DL.Text = rectangleCurve_DL_Retrieved.ToString();
            rectangle_Border_DR.Text = rectangleCurve_DR_Retrieved.ToString();
            //rectangle_Border_ALL.Text = shapePopulate.Curve.ToString();

            rectangleShape.UpperLeftCurve = shapePopulate.UpperLeftCurve / 4;
            rectangleShape.UpperRightCurve = shapePopulate.UpperRightCurve / 4;
            rectangleShape.DownLeftCurve = shapePopulate.DownLeftCurve / 4;
            rectangleShape.DownRightCurve = shapePopulate.DownRightCurve / 4;
            rectangleShape.Curve = shapePopulate.Curve;


            rectangleShape.BorderWidth = (shapePopulate.BorderWidth) / 4;
            circleShape.BorderWidth = shapePopulate.BorderWidth;
            pieShape.BorderWidth = shapePopulate.BorderWidth;
            polygonShape.BorderWidth = shapePopulate.BorderWidth;
            
            rectangle_Curve_Numeric.Value = shapePopulate.Curve;
            rectangle_Border_Width_Numeric.Value = Convert.ToDecimal(shapePopulate.BorderWidth);
            rectangle_Color.BackColor = shapePopulate.ShapeColor;
            rectangle_BorderColor.BackColor = shapePopulate.BorderColor;

            circle_Border_Width_Numeric.Value = Convert.ToDecimal(shapePopulate.BorderWidth);
            circle_Color.BackColor = shapePopulate.ShapeColor;
            circle_BorderColor.BackColor = shapePopulate.BorderColor;

            pie_Border_Width_Numeric.Value = Convert.ToDecimal(shapePopulate.BorderWidth);
            pie_Color.BackColor = shapePopulate.ShapeColor;
            pie_BorderColor.BackColor = shapePopulate.BorderColor;

            polygon_Border_Width_Numeric.Value = Convert.ToDecimal(shapePopulate.BorderWidth);
            polygon_Color.BackColor = shapePopulate.ShapeColor;
            polygon_BorderColor.BackColor = shapePopulate.BorderColor;
            
            polygon_Sides_Numeric.Value = Convert.ToDecimal(shapePopulate.PolygonSides);
            polygon_Angle_Numeric.Value = Convert.ToDecimal(shapePopulate.PolygonStartingAngle);
            polygonShape.PolygonSides = shapePopulate.PolygonSides;
            polygonShape.PolygonStartingAngle = shapePopulate.PolygonStartingAngle;

            pie_StartAngle_Numeric.Value = Convert.ToDecimal(shapePopulate.StartAngle);
            pie_EndAngle_Numeric.Value = Convert.ToDecimal(shapePopulate.EndAngle);

            pieShape.StartAngle = shapePopulate.StartAngle;
            pieShape.EndAngle = shapePopulate.EndAngle;

            if (shapePopulate.ColorShape == true)
            {
                rectangleShape.ShapeColor = shapePopulate.ShapeColor;
                circleShape.ShapeColor = rectangle_Color.BackColor;
                pieShape.ShapeColor = rectangle_Color.BackColor;
                polygonShape.ShapeColor = rectangle_Color.BackColor;
            }

            if (shapePopulate.DrawBorder)
            {
                rectangleShape.BorderColor = shapePopulate.BorderColor;
                circleShape.BorderColor = rectangle_BorderColor.BackColor;
                pieShape.BorderColor = rectangle_BorderColor.BackColor;
                polygonShape.BorderColor = rectangle_BorderColor.BackColor;

            }

            if (shapePopulate.Shape == Shapes.Rectangle)
            {
                rectangle_RadioBtn.Checked = true;
                
            }
            
            else if (shapePopulate.Shape == Shapes.Circle)
            {
                circle_RadioBtn.Checked = true;
            }
            else if (shapePopulate.Shape == Shapes.Polygon)
            {
                polygon_RadioBtn.Checked = true;
            }
            else if (shapePopulate.Shape == Shapes.Pie)
            {
                pie_RadioBtn.Checked = true;
            }
            else
            {
                none_RadioBtn.Checked = true;
            }
        }


        /// <summary>
        /// Sets the control rectangle to initial values.
        /// </summary>
        /// <param name="shapePopulate">The shape populate.</param>
        private void SetControl_Rectangle_To_Initial_Values(ShapeInput shapePopulate)
        {

            if (shapePopulate.Rounding)
            {
                rectangle_Rounding_Combo.SelectedIndex = Yes;
                rectangleShape.Rounding = true;
            }
            else
            {
                rectangle_Rounding_Combo.SelectedIndex = No;
                rectangleShape.Rounding = false;
            }

            if (shapePopulate.DrawBorder)
            {
                rectangle_Border_Combo.SelectedIndex = Yes;
                circle_Border_Combo.SelectedIndex = Yes;
                pie_Border_Combo.SelectedIndex = Yes;
                polygon_Border_Combo.SelectedIndex = Yes;
            }
            else
            {
                rectangle_Border_Combo.SelectedIndex = No;
                circle_Border_Combo.SelectedIndex = No;
                pie_Border_Combo.SelectedIndex = No;
                polygon_Border_Combo.SelectedIndex = No;
            }

            if (shapePopulate.ColorShape)
            {
                rectangle_Colored_Combo.SelectedIndex = Yes;
                circle_Colored_Combo.SelectedIndex = Yes;
                pie_Colored_Combo.SelectedIndex = Yes;
                polygon_Colored_Combo.SelectedIndex = Yes;
            }
            else
            {
                rectangle_Colored_Combo.SelectedIndex = No;
                circle_Colored_Combo.SelectedIndex = No;
                pie_Colored_Combo.SelectedIndex = No;
                polygon_Colored_Combo.SelectedIndex = No;
            }
            
            

            rectangleCurve_UL_Retrieved = shapePopulate.UpperLeftCurve;
            rectangleCurve_UR_Retrieved = shapePopulate.UpperRightCurve;
            rectangleCurve_DL_Retrieved = shapePopulate.DownLeftCurve;
            rectangleCurve_DR_Retrieved = shapePopulate.DownRightCurve;

            rectangle_Border_UL.Text = rectangleCurve_UL_Retrieved.ToString();
            rectangle_Border_UR.Text = rectangleCurve_UR_Retrieved.ToString();
            rectangle_Border_DL.Text = rectangleCurve_DL_Retrieved.ToString();
            rectangle_Border_DR.Text = rectangleCurve_DR_Retrieved.ToString();
            rectangle_Border_ALL.Text = shapePopulate.Curve.ToString();

            rectangleShape.UpperLeftCurve = shapePopulate.UpperLeftCurve;
            rectangleShape.UpperRightCurve = shapePopulate.UpperRightCurve;
            rectangleShape.DownLeftCurve = shapePopulate.DownLeftCurve;
            rectangleShape.DownRightCurve = shapePopulate.DownRightCurve;
            rectangleShape.Curve = shapePopulate.Curve;

            
            rectangleShape.BorderWidth = (shapePopulate.BorderWidth) / 4;

            rectangle_Curve_Numeric.Value = shapePopulate.Curve;
            rectangle_Border_Width_Numeric.Value = Convert.ToDecimal(shapePopulate.BorderWidth);
            rectangle_Color.BackColor = shapePopulate.ShapeColor;
            rectangle_BorderColor.BackColor = shapePopulate.BorderColor;

            circle_Border_Width_Numeric.Value = Convert.ToDecimal(shapePopulate.BorderWidth);
            circle_Color.BackColor = shapePopulate.ShapeColor;
            circle_BorderColor.BackColor = shapePopulate.BorderColor;

            pie_Border_Width_Numeric.Value = Convert.ToDecimal(shapePopulate.BorderWidth);
            pie_Color.BackColor = shapePopulate.ShapeColor;
            pie_BorderColor.BackColor = shapePopulate.BorderColor;

            polygon_Border_Width_Numeric.Value = Convert.ToDecimal(shapePopulate.BorderWidth);
            polygon_Color.BackColor = shapePopulate.ShapeColor;
            polygon_BorderColor.BackColor = shapePopulate.BorderColor;


            if (shapePopulate.ColorShape == true)
            {
                rectangleShape.ShapeColor = shapePopulate.ShapeColor;
                circleShape.ShapeColor = rectangle_Color.BackColor;
                pieShape.ShapeColor = rectangle_Color.BackColor;
                polygonShape.ShapeColor = rectangle_Color.BackColor;
            }

            if (shapePopulate.DrawBorder)
            {
                rectangleShape.BorderColor = shapePopulate.BorderColor;
                circleShape.BorderColor = rectangle_BorderColor.BackColor;
                pieShape.BorderColor = rectangle_BorderColor.BackColor;
                polygonShape.BorderColor = rectangle_BorderColor.BackColor;

            }

            if (shapePopulate.Shape == Shapes.Rectangle)
            {
                rectangle_RadioBtn.Checked = true;

                


                //if (shapePopulate.Rounding == true)
                //{
                //    rectangle_Rounding_Combo.SelectedIndex = Yes;
                //    rectangleShape.Rounding = true;
                    
                //}
                //else if (shapePopulate.Rounding == false)
                //{
                //    rectangle_Rounding_Combo.SelectedIndex = No;
                //    rectangleShape.Rounding = false;
                //}

                //if (shapePopulate.DrawBorder == true)
                //{
                //    rectangle_Border_Combo.SelectedIndex = Yes;
                //    rectangleShape.DrawBorder = true;
                //}
                //else if (shapePopulate.DrawBorder == false)
                //{
                //    rectangle_Border_Combo.SelectedIndex = No;
                //    rectangleShape.DrawBorder = false;
                //}

                //if (shapePopulate.ColorShape == true)
                //{
                //    rectangle_Colored_Combo.SelectedIndex = Yes;
                //    rectangleShape.ColorShape = true;
                //}
                //else if (shapePopulate.ColorShape == false)
                //{
                //    rectangle_Colored_Combo.SelectedIndex = No;
                //    rectangleShape.ColorShape = false;

                //}

            }

            

            else if (shapePopulate.Shape == Shapes.Circle)
            {
                circle_RadioBtn.Checked = true;
            }
            else if (shapePopulate.Shape == Shapes.Polygon)
            {
                polygon_RadioBtn.Checked = true;
            }
            else if (shapePopulate.Shape == Shapes.Pie)
            {
                pie_RadioBtn.Checked = true;
            }
            else
            {
                none_RadioBtn.Checked = true;
            }
        }

        /// <summary>
        /// Sets the control rectangle passed values.
        /// </summary>
        /// <param name="shapePopulate">The shape populate.</param>
        private void SetControl_Rectangle_Passed_Values(ShapeInput shapePopulate)
        {

            shapePopulate.Shape = Shapes.Rectangle;

            shapePopulate.Rounding = bool.Parse(rectangleRounding_Retrieved);
            shapePopulate.DrawBorder = bool.Parse(rectangleBorder_Retrieved);
            shapePopulate.ColorShape = bool.Parse(rectangleColored_Retrieved);
            shapePopulate.Curve = rectangleCurve_Retrieved;
            shapePopulate.BorderWidth = (int)rectangle_Border_Width_Numeric.Value;
            shapePopulate.ShapeColor = rectangle_Color.BackColor;
            shapePopulate.BorderColor = rectangle_BorderColor.BackColor;

            shapePopulate.UpperLeftCurve = rectangleCurve_UL_Retrieved * 4;
            shapePopulate.UpperRightCurve = rectangleCurve_UR_Retrieved * 4;
            shapePopulate.DownLeftCurve = rectangleCurve_DL_Retrieved * 4;
            shapePopulate.DownRightCurve = rectangleCurve_DR_Retrieved * 4;

        }

        /// <summary>
        /// Sets the controls circle to initial values.
        /// </summary>
        /// <param name="shapePopulate">The shape populate.</param>
        private void SetControls_Circle_To_Initial_Values(ShapeInput shapePopulate)
        {
           
            

            circle_Border_Combo.SelectedIndex = No;
            circle_Colored_Combo.SelectedIndex = No;
            

            if (shapePopulate.Shape == Shapes.Circle)
            {
                circle_RadioBtn.Checked = true;
                
                circle_Border_Width_Numeric.Value = Convert.ToDecimal(shapePopulate.BorderWidth);
                circle_Color.BackColor = shapePopulate.ShapeColor;
                circle_BorderColor.BackColor = shapePopulate.BorderColor;


                circleShape.BorderWidth = shapePopulate.BorderWidth;
                //circleShape.ShapeColor = shapePopulate.ShapeColor;
                //circleShape.BorderColor = shapePopulate.BorderColor;

                circleShape.BorderColor = circle_BorderColor.BackColor;
                circleShape.ShapeColor = circle_Color.BackColor;

                if (shapePopulate.DrawBorder == true)
                {
                    circle_Border_Combo.SelectedIndex = Yes;
                    circleShape.DrawBorder = true;
                }
                else if (shapePopulate.DrawBorder == false)
                {
                    circle_Border_Combo.SelectedIndex = No;
                    circleShape.DrawBorder = false;
                }

                if (shapePopulate.ColorShape == true)
                {
                    circle_Colored_Combo.SelectedIndex = Yes;
                    circleShape.ColorShape = true;
                }
                else if (shapePopulate.ColorShape == false)
                {
                    circle_Colored_Combo.SelectedIndex = No;
                    circleShape.ColorShape = false;

                }

            }
            


            else if (shapePopulate.Shape == Shapes.Rectangle)
            {
                rectangle_RadioBtn.Checked = true;
            }
            else if (shapePopulate.Shape == Shapes.Polygon)
            {
                polygon_RadioBtn.Checked = true;
            }
            else if (shapePopulate.Shape == Shapes.Pie)
            {
                pie_RadioBtn.Checked = true;
            }
            else
            {
                none_RadioBtn.Checked = true;
            }
        }

        /// <summary>
        /// Sets the control circle passed values.
        /// </summary>
        /// <param name="shapePopulate">The shape populate.</param>
        private void SetControl_Circle_Passed_Values(ShapeInput shapePopulate)
        {

            shapePopulate.Shape = Shapes.Circle;

            shapePopulate.DrawBorder = bool.Parse(circleBorder_Retrieved);
            shapePopulate.ColorShape = bool.Parse(circleColored_Retrieved);
            shapePopulate.BorderWidth = (int)circle_Border_Width_Numeric.Value;
            shapePopulate.ShapeColor = circle_Color.BackColor;
            shapePopulate.BorderColor = circle_BorderColor.BackColor;
            

        }

        /// <summary>
        /// Sets the controls polygon to initial values.
        /// </summary>
        /// <param name="shapePopulate">The shape populate.</param>
        private void SetControls_Polygon_To_Initial_Values(ShapeInput shapePopulate)
        {



            polygon_Border_Combo.SelectedIndex = No;
            polygon_Colored_Combo.SelectedIndex = No;


            if (shapePopulate.Shape == Shapes.Polygon)
            {
                polygon_RadioBtn.Checked = true;

                polygon_Border_Width_Numeric.Value = Convert.ToDecimal(shapePopulate.BorderWidth);
                polygon_Color.BackColor = shapePopulate.ShapeColor;
                polygon_BorderColor.BackColor = shapePopulate.BorderColor;
                polygon_Sides_Numeric.Value = Convert.ToDecimal(shapePopulate.PolygonSides);
                polygon_Angle_Numeric.Value = Convert.ToDecimal(shapePopulate.PolygonStartingAngle);


                polygonShape.BorderWidth = shapePopulate.BorderWidth;
                polygonShape.PolygonSides = shapePopulate.PolygonSides;
                polygonShape.PolygonStartingAngle = shapePopulate.PolygonStartingAngle;

                //polygonShape.ShapeColor = shapePopulate.ShapeColor;
                //polygonShape.BorderColor = shapePopulate.BorderColor;

                polygonShape.ShapeColor = polygon_Color.BackColor;
                polygonShape.BorderColor = polygon_BorderColor.BackColor;

                if (shapePopulate.DrawBorder == true)
                {
                    polygon_Border_Combo.SelectedIndex = Yes;
                    polygonShape.DrawBorder = true;
                }
                else if (shapePopulate.DrawBorder == false)
                {
                    polygon_Border_Combo.SelectedIndex = No;
                    polygonShape.DrawBorder = false;
                }

                if (shapePopulate.ColorShape == true)
                {
                    polygon_Colored_Combo.SelectedIndex = Yes;
                    polygonShape.ColorShape = true;
                }
                else if (shapePopulate.ColorShape == false)
                {
                    polygon_Colored_Combo.SelectedIndex = No;
                    polygonShape.ColorShape = false;

                }

            }



            else if (shapePopulate.Shape == Shapes.Circle)
            {
                circle_RadioBtn.Checked = true;
            }
            else if (shapePopulate.Shape == Shapes.Rectangle)
            {
                rectangle_RadioBtn.Checked = true;
            }
            else if (shapePopulate.Shape == Shapes.Pie)
            {
                pie_RadioBtn.Checked = true;
            }
            else
            {
                none_RadioBtn.Checked = true;
            }
        }

        /// <summary>
        /// Sets the control polygon passed values.
        /// </summary>
        /// <param name="shapePopulate">The shape populate.</param>
        private void SetControl_Polygon_Passed_Values(ShapeInput shapePopulate)
        {

            shapePopulate.Shape = Shapes.Polygon;

            shapePopulate.DrawBorder = bool.Parse(polygonBorder_Retrieved);
            shapePopulate.ColorShape = bool.Parse(polygonColored_Retrieved);
            shapePopulate.BorderWidth = (int)polygon_Border_Width_Numeric.Value;
            shapePopulate.ShapeColor = polygon_Color.BackColor;
            shapePopulate.BorderColor = polygon_BorderColor.BackColor;
            shapePopulate.PolygonStartingAngle = polygonAngle_Retrieved;
            shapePopulate.PolygonSides = polygonSides_Retrieved;


        }

        /// <summary>
        /// Sets the controls pie to initial values.
        /// </summary>
        /// <param name="shapePopulate">The shape populate.</param>
        private void SetControls_Pie_To_Initial_Values(ShapeInput shapePopulate)
        {



            pie_Border_Combo.SelectedIndex = No;
            pie_Colored_Combo.SelectedIndex = No;


            if (shapePopulate.Shape == Shapes.Pie)
            {
                pie_RadioBtn.Checked = true;

                pie_Border_Width_Numeric.Value = Convert.ToDecimal(shapePopulate.BorderWidth);
                pie_Color.BackColor = shapePopulate.ShapeColor;
                pie_BorderColor.BackColor = shapePopulate.BorderColor;
                pie_StartAngle_Numeric.Value = Convert.ToDecimal(shapePopulate.StartAngle);
                pie_EndAngle_Numeric.Value = Convert.ToDecimal(shapePopulate.EndAngle);


                pieShape.BorderWidth = shapePopulate.BorderWidth;
                pieShape.StartAngle = shapePopulate.StartAngle;
                pieShape.EndAngle = shapePopulate.EndAngle;

                //pieShape.ShapeColor = shapePopulate.ShapeColor;
                //pieShape.BorderColor = shapePopulate.BorderColor;

                pieShape.ShapeColor = pie_Color.BackColor;
                pieShape.BorderColor = pie_BorderColor.BackColor;


                if (shapePopulate.DrawBorder == true)
                {
                    pie_Border_Combo.SelectedIndex = Yes;
                    pieShape.DrawBorder = true;
                }
                else if (shapePopulate.DrawBorder == false)
                {
                    pie_Border_Combo.SelectedIndex = No;
                    pieShape.DrawBorder = false;
                }

                if (shapePopulate.ColorShape == true)
                {
                    pie_Colored_Combo.SelectedIndex = Yes;
                    pieShape.ColorShape = true;
                }
                else if (shapePopulate.ColorShape == false)
                {
                    pie_Colored_Combo.SelectedIndex = No;
                    pieShape.ColorShape = false;

                }

            }



            else if (shapePopulate.Shape == Shapes.Circle)
            {
                circle_RadioBtn.Checked = true;
            }
            else if (shapePopulate.Shape == Shapes.Rectangle)
            {
                rectangle_RadioBtn.Checked = true;
            }
            else if (shapePopulate.Shape == Shapes.Polygon)
            {
                polygon_RadioBtn.Checked = true;
            }
            else
            {
                none_RadioBtn.Checked = true;
            }
        }

        /// <summary>
        /// Sets the control pie passed values.
        /// </summary>
        /// <param name="shapePopulate">The shape populate.</param>
        private void SetControl_Pie_Passed_Values(ShapeInput shapePopulate)
        {
            shapePopulate.Shape = Shapes.Pie;

            shapePopulate.DrawBorder = bool.Parse(pieBorder_Retrieved);
            shapePopulate.ColorShape = bool.Parse(pieColored_Retrieved);
            shapePopulate.BorderWidth = (int)pie_Border_Width_Numeric.Value;
            shapePopulate.ShapeColor = pie_Color.BackColor;
            shapePopulate.BorderColor = pie_BorderColor.BackColor;
            shapePopulate.StartAngle = pie_StartAngle_Retrieved;
            shapePopulate.EndAngle = pie_EndAngle_Retrieved;


        }



        #endregion

        #region Rectangle




        #endregion

        #region Knob Creation

        /// <summary>
        /// The polygon sides knob
        /// </summary>
        private Helper.ZeroitLBKnob polygonSidesKnob = new Zeroit.Framework.Button.Helper.ZeroitLBKnob();

        /// <summary>
        /// The polygon angle knob
        /// </summary>
        private Helper.ZeroitLBKnob polygonAngleKnob = new Zeroit.Framework.Button.Helper.ZeroitLBKnob();

        /// <summary>
        /// The pie start knob
        /// </summary>
        private Helper.ZeroitLBKnob pieStartKnob = new Zeroit.Framework.Button.Helper.ZeroitLBKnob();

        /// <summary>
        /// The pie end knob
        /// </summary>
        private Helper.ZeroitLBKnob pieEndKnob = new Zeroit.Framework.Button.Helper.ZeroitLBKnob();


        /// <summary>
        /// Polygons the sides knob added.
        /// </summary>
        private void PolygonSidesKnob_Added()
        {
            this.polygon_GroupBox.Controls.Add(this.polygonSidesKnob);

            // 
            // zeroitLBKnob1
            // 
            this.polygonSidesKnob.BackColor = System.Drawing.Color.Transparent;
            this.polygonSidesKnob.DrawRatio = 0.33F;
            this.polygonSidesKnob.IndicatorColor = System.Drawing.Color.Black;
            this.polygonSidesKnob.IndicatorOffset = 10F;
            this.polygonSidesKnob.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.polygonSidesKnob.Location = new System.Drawing.Point(464, 15);
            this.polygonSidesKnob.MaxValue = 100F;
            this.polygonSidesKnob.MinValue = 3F;
            this.polygonSidesKnob.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.polygonSidesKnob.Size = new System.Drawing.Size(70, 66);
            this.polygonSidesKnob.StepValue = 0.1F;
            this.polygonSidesKnob.Style = Zeroit.Framework.Button.Helper.ZeroitLBKnob.KnobStyle.Circular;
            this.polygonSidesKnob.Value = (float)polygon_Sides_Numeric.Value;
            this.polygonSidesKnob.Visible = true;
            this.polygonSidesKnob.KnobChangeValue += new Zeroit.Framework.Button.Helper.KnobChangeValue(this.polygonSides_KnobChangeValue);


        }

        /// <summary>
        /// Polygons the sides knob removed.
        /// </summary>
        private void PolygonSidesKnob_Removed()
        {
            this.polygon_GroupBox.Controls.Remove(this.polygonSidesKnob);
            this.polygonSidesKnob.Visible = false;
        }

        /// <summary>
        /// Polygons the angle knob added.
        /// </summary>
        private void PolygonAngleKnob_Added()
        {
            this.polygon_GroupBox.Controls.Add(this.polygonAngleKnob);

            // 
            // zeroitLBKnob1
            // 
            this.polygonAngleKnob.BackColor = System.Drawing.Color.Transparent;
            this.polygonAngleKnob.DrawRatio = 0.33F;
            this.polygonAngleKnob.IndicatorColor = System.Drawing.Color.Black;
            this.polygonAngleKnob.IndicatorOffset = 10F;
            this.polygonAngleKnob.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.polygonAngleKnob.Location = new System.Drawing.Point(464, 70);
            this.polygonAngleKnob.MaxValue = 360F;
            this.polygonAngleKnob.MinValue = 0F;
            this.polygonAngleKnob.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.polygonAngleKnob.Size = new System.Drawing.Size(70, 66);
            this.polygonAngleKnob.StepValue = 0.1F;
            this.polygonAngleKnob.Style = Zeroit.Framework.Button.Helper.ZeroitLBKnob.KnobStyle.Circular;
            this.polygonAngleKnob.Value = (float)polygon_Angle_Numeric.Value;
            this.polygonAngleKnob.Visible = true;
            this.polygonAngleKnob.KnobChangeValue += new Zeroit.Framework.Button.Helper.KnobChangeValue(this.polygonAngle_KnobChangeValue);


        }

        /// <summary>
        /// Polygons the angle knob removed.
        /// </summary>
        private void PolygonAngleKnob_Removed()
        {
            this.polygon_GroupBox.Controls.Remove(this.polygonAngleKnob);
            this.polygonAngleKnob.Visible = false;
        }

        /// <summary>
        /// Pies the start knob added.
        /// </summary>
        private void PieStartKnob_Added()
        {
            this.pie_GroupBox.Controls.Add(this.pieStartKnob);

            // 
            // zeroitLBKnob1
            // 
            this.pieStartKnob.BackColor = System.Drawing.Color.Transparent;
            this.pieStartKnob.DrawRatio = 0.33F;
            this.pieStartKnob.IndicatorColor = System.Drawing.Color.Black;
            this.pieStartKnob.IndicatorOffset = 10F;
            this.pieStartKnob.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.pieStartKnob.Location = new System.Drawing.Point(468, 16);
            this.pieStartKnob.MaxValue = 360F;
            this.pieStartKnob.MinValue = 0F;
            this.pieStartKnob.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pieStartKnob.Size = new System.Drawing.Size(70, 66);
            this.pieStartKnob.StepValue = 0.1F;
            this.pieStartKnob.Style = Zeroit.Framework.Button.Helper.ZeroitLBKnob.KnobStyle.Circular;
            this.pieStartKnob.Value = (float)pie_StartAngle_Numeric.Value;
            this.pieStartKnob.Visible = true;
            this.pieStartKnob.KnobChangeValue += new Zeroit.Framework.Button.Helper.KnobChangeValue(this.pieStartAngle_KnobChangeValue);


        }

        /// <summary>
        /// Pies the start knob removed.
        /// </summary>
        private void PieStartKnob_Removed()
        {
            this.pie_GroupBox.Controls.Remove(this.pieStartKnob);
            this.pieStartKnob.Visible = false;
        }

        /// <summary>
        /// Pies the end knob added.
        /// </summary>
        private void PieEndKnob_Added()
        {
            this.pie_GroupBox.Controls.Add(this.pieEndKnob);

            // 
            // zeroitLBKnob1
            // 
            this.pieEndKnob.BackColor = System.Drawing.Color.Transparent;
            this.pieEndKnob.DrawRatio = 0.33F;
            this.pieEndKnob.IndicatorColor = System.Drawing.Color.Black;
            this.pieEndKnob.IndicatorOffset = 10F;
            this.pieEndKnob.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.pieEndKnob.Location = new System.Drawing.Point(468, 68);
            this.pieEndKnob.MaxValue = 360F;
            this.pieEndKnob.MinValue = 0F;
            this.pieEndKnob.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pieEndKnob.Size = new System.Drawing.Size(70, 66);
            this.pieEndKnob.StepValue = 0.1F;
            this.pieEndKnob.Style = Zeroit.Framework.Button.Helper.ZeroitLBKnob.KnobStyle.Circular;
            this.pieEndKnob.Value = (float)pie_EndAngle_Numeric.Value;
            this.pieEndKnob.Visible = true;
            this.pieEndKnob.KnobChangeValue += new Zeroit.Framework.Button.Helper.KnobChangeValue(this.pieEndAngle_KnobChangeValue);


        }

        /// <summary>
        /// Pies the end knob removed.
        /// </summary>
        private void PieEndKnob_Removed()
        {
            this.pie_GroupBox.Controls.Remove(this.pieEndKnob);
            this.pieEndKnob.Visible = false;
        }

        /// <summary>
        /// Handles the KnobChangeValue event of the polygonSides control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Helper.ZeroitLBKnobEventArgs"/> instance containing the event data.</param>
        private void polygonSides_KnobChangeValue(object sender, Helper.ZeroitLBKnobEventArgs e)
        {
            this.polygonSidesKnob.ScaleColor = Color.Aqua;
            polygon_Sides_Numeric.Value = (decimal)polygonSidesKnob.Value;
        }

        /// <summary>
        /// Handles the KnobChangeValue event of the polygonAngle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Helper.ZeroitLBKnobEventArgs"/> instance containing the event data.</param>
        private void polygonAngle_KnobChangeValue(object sender, Helper.ZeroitLBKnobEventArgs e)
        {
            this.polygonAngleKnob.ScaleColor = Color.Aqua;
            polygon_Angle_Numeric.Value = (decimal)polygonAngleKnob.Value;
        }

        /// <summary>
        /// Handles the KnobChangeValue event of the pieStartAngle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Helper.ZeroitLBKnobEventArgs"/> instance containing the event data.</param>
        private void pieStartAngle_KnobChangeValue(object sender, Helper.ZeroitLBKnobEventArgs e)
        {
            this.pieStartKnob.ScaleColor = Color.Aqua;
            pie_StartAngle_Numeric.Value = (decimal)pieStartKnob.Value;
        }

        /// <summary>
        /// Handles the KnobChangeValue event of the pieEndAngle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Helper.ZeroitLBKnobEventArgs"/> instance containing the event data.</param>
        private void pieEndAngle_KnobChangeValue(object sender, Helper.ZeroitLBKnobEventArgs e)
        {
            this.pieEndKnob.ScaleColor = Color.Aqua;
            pie_EndAngle_Numeric.Value = (decimal)pieEndKnob.Value;
        }


        #endregion

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rectangle_Rounding_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_Rounding_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (rectangle_Rounding_Combo.SelectedIndex == Yes)
            {
                rectangleRounding_Retrieved = "true";
                rectangleShape.Rounding = true;

                
            }
            else if(rectangle_Rounding_Combo.SelectedIndex == No)
            {
                rectangleRounding_Retrieved = "false";
                rectangleShape.Rounding = false;
                
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the rectangle_Curve_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_Curve_Numeric_ValueChanged(object sender, EventArgs e)
        {
            rectangleCurve_Retrieved = (int)rectangle_Curve_Numeric.Value;
            rectangleShape.Curve = rectangleCurve_Retrieved;

            rectangleCurve_UL_Retrieved = rectangleCurve_Retrieved;
            rectangleCurve_UR_Retrieved = rectangleCurve_Retrieved;
            rectangleCurve_DL_Retrieved = rectangleCurve_Retrieved;
            rectangleCurve_DR_Retrieved = rectangleCurve_Retrieved;

            rectangle_Border_UL.Text = rectangleCurve_Retrieved.ToString();
            rectangle_Border_UR.Text = rectangleCurve_Retrieved.ToString();
            rectangle_Border_DL.Text = rectangleCurve_Retrieved.ToString();
            rectangle_Border_DR.Text = rectangleCurve_Retrieved.ToString();
            rectangle_Border_ALL.Text = rectangleCurve_Retrieved.ToString();

        }


        /// <summary>
        /// Handles the TextChanged event of the rectangle_Border_UL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_Border_UL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rectangle_Border_UL.Text == string.Empty)
                {
                    rectangleShape.UpperLeftCurve = 3;
                }

                int valueConverted = int.Parse(rectangle_Border_UL.Text);

                rectangleCurve_UL_Retrieved = valueConverted;

                rectangleShape.UpperLeftCurve = rectangleCurve_UL_Retrieved;


            }
            catch (Exception exception)
            {

                rectangleShape.UpperLeftCurve = 3;

            }
        }

        /// <summary>
        /// Handles the TextChanged event of the rectangle_Border_UR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_Border_UR_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rectangle_Border_UR.Text == string.Empty)
                {
                    rectangleShape.UpperRightCurve = 3;
                }

                int valueConverted = int.Parse(rectangle_Border_UR.Text);
                rectangleCurve_UR_Retrieved = valueConverted;

                rectangleShape.UpperRightCurve = rectangleCurve_UR_Retrieved;
            }
            catch (Exception exception)
            {

                rectangleShape.UpperRightCurve = 3;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the rectangle_Border_DL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_Border_DL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rectangle_Border_DL.Text == string.Empty)
                {
                    rectangleShape.DownLeftCurve = 3;
                }
                int valueConverted = int.Parse(rectangle_Border_DL.Text);
                rectangleCurve_DL_Retrieved = valueConverted;

                rectangleShape.DownLeftCurve = rectangleCurve_DL_Retrieved;
            }
            catch (Exception exception)
            {

                rectangleShape.DownLeftCurve = 3;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the rectangle_Border_DR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_Border_DR_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rectangle_Border_DR.Text == string.Empty)
                {
                    rectangleShape.DownRightCurve = 3;
                }
                int valueConverted = int.Parse(rectangle_Border_DR.Text);
                rectangleCurve_DR_Retrieved = valueConverted;

                rectangleShape.DownRightCurve = rectangleCurve_DR_Retrieved;
            }
            catch (Exception exception)
            {

                rectangleShape.DownRightCurve = 3;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the rectangle_Border_ALL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_Border_ALL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rectangle_Border_ALL.Text == string.Empty)
                {
                    rectangleShape.Curve = 3;
                }
                int valueConverted = int.Parse(rectangle_Border_ALL.Text);
                rectangleCurve_Retrieved = valueConverted;

                rectangleShape.Curve = rectangleCurve_Retrieved;

                rectangle_Border_UL.Text = rectangleCurve_Retrieved.ToString();
                rectangle_Border_UR.Text = rectangleCurve_Retrieved.ToString();
                rectangle_Border_DL.Text = rectangleCurve_Retrieved.ToString();
                rectangle_Border_DR.Text = rectangleCurve_Retrieved.ToString();

                rectangleShape.UpperLeftCurve = rectangleCurve_Retrieved;
                rectangleShape.UpperRightCurve = rectangleCurve_Retrieved;
                rectangleShape.DownLeftCurve = rectangleCurve_Retrieved;
                rectangleShape.DownRightCurve = rectangleCurve_Retrieved;
            }
            catch (Exception exception)
            {

                rectangleShape.Curve = 3;
            }
        }


        /// <summary>
        /// Handles the ValueChanged event of the polygon_Sides control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_Sides_ValueChanged(object sender, EventArgs e)
        {
            polygonSides_Retrieved = (int)polygon_Sides_Numeric.Value;
            polygonShape.PolygonSides = polygonSides_Retrieved;
        }

        /// <summary>
        /// Handles the ValueChanged event of the polygon_Angle_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_Angle_Numeric_ValueChanged(object sender, EventArgs e)
        {
            polygonAngle_Retrieved = (int)polygon_Angle_Numeric.Value;
            polygonShape.PolygonStartingAngle = polygonAngle_Retrieved;
        }


        /// <summary>
        /// Handles the ValueChanged event of the pie_StartAngle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_StartAngle_ValueChanged(object sender, EventArgs e)
        {

            pie_StartAngle_Retrieved = (int)pie_StartAngle_Numeric.Value;
            pieShape.StartAngle = pie_StartAngle_Retrieved;
        }

        /// <summary>
        /// Handles the ValueChanged event of the pie_EndAngle_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_EndAngle_Numeric_ValueChanged(object sender, EventArgs e)
        {
            pie_EndAngle_Retrieved = (int)pie_EndAngle_Numeric.Value;
            pieShape.EndAngle = pie_EndAngle_Retrieved;
        }




        /// <summary>
        /// Handles the SelectedIndexChanged event of the rectangle_Border_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_Border_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rectangle_Border_Combo.SelectedIndex == Yes)
            {
                rectangleBorder_Retrieved = "true";
                rectangleShape.DrawBorder = true;

                rectangleShape.BorderColor = rectangleBorderColor_Retrieved;
            }
            else if(rectangle_Border_Combo.SelectedIndex == No)
            {
                rectangleBorder_Retrieved = "false";
                rectangleShape.DrawBorder = false;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the circle_Border_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void circle_Border_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (circle_Border_Combo.SelectedIndex == Yes)
            {
                circleBorder_Retrieved = "true";
                circleShape.DrawBorder = true;

                circleShape.BorderColor = circleBorderColor_Retrieved;
            }
            else if (circle_Border_Combo.SelectedIndex == No)
            {
                circleBorder_Retrieved = "false";
                circleShape.DrawBorder = false;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the polygon_Border_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_Border_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (polygon_Border_Combo.SelectedIndex == Yes)
            {
                polygonBorder_Retrieved = "true";
                polygonShape.DrawBorder = true;

                polygonShape.BorderColor = polygonBorderColor_Retrieved;
            }
            else if (polygon_Border_Combo.SelectedIndex == No)
            {
                polygonBorder_Retrieved = "false";
                polygonShape.DrawBorder = false;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the pie_Border_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_Border_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pie_Border_Combo.SelectedIndex == Yes)
            {
                pieBorder_Retrieved = "true";
                pieShape.DrawBorder = true;

                pieShape.BorderColor = pieBorderColor_Retrieved;
            }
            else if (pie_Border_Combo.SelectedIndex == No)
            {
                pieBorder_Retrieved = "false";
                pieShape.DrawBorder = false;
            }
        }



        /// <summary>
        /// Handles the SelectedIndexChanged event of the rectangle_Colored_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_Colored_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rectangle_Colored_Combo.SelectedIndex == Yes)
            {
                rectangleColored_Retrieved = "true";
                rectangleShape.ColorShape = true;

                rectangleShape.ShapeColor = rectangleColor_Retrieved;

            }
            else if(rectangle_Colored_Combo.SelectedIndex == No)
            {
                rectangleColored_Retrieved = "false";
                rectangleShape.ColorShape = false;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the circle_Colored_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void circle_Colored_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (circle_Colored_Combo.SelectedIndex == Yes)
            {
                circleColored_Retrieved = "true";
                circleShape.ColorShape = true;

                circleShape.ShapeColor = circleColor_Retrieved;
            }
            else if (circle_Colored_Combo.SelectedIndex == No)
            {
                circleColored_Retrieved = "false";
                circleShape.ColorShape = false;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the polygon_Colored_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_Colored_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (polygon_Colored_Combo.SelectedIndex == Yes)
            {
                polygonColored_Retrieved = "true";
                polygonShape.ColorShape = true;

                polygonShape.ShapeColor = polygonColor_Retrieved;
            }
            else if (polygon_Colored_Combo.SelectedIndex == No)
            {
                polygonColored_Retrieved = "false";
                polygonShape.ColorShape = false;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the pie_Colored_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_Colored_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pie_Colored_Combo.SelectedIndex == Yes)
            {
                pieColored_Retrieved = "true";
                pieShape.ColorShape = true;

                pieShape.ShapeColor = pieColor_Retrieved;
            }
            else if (pie_Colored_Combo.SelectedIndex == No)
            {
                pieColored_Retrieved = "false";
                pieShape.ColorShape = false;
            }
        }




        /// <summary>
        /// Handles the ValueChanged event of the rectangle_Border_Width_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_Border_Width_Numeric_ValueChanged(object sender, EventArgs e)
        {
            rectangleBorderWidth_Retrieved = (int) rectangle_Border_Width_Numeric.Value;
            rectangleShape.BorderWidth = rectangleBorderWidth_Retrieved;
        }

        /// <summary>
        /// Handles the ValueChanged event of the circle_Border_Width_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void circle_Border_Width_Numeric_ValueChanged(object sender, EventArgs e)
        {
            circleBorderWidth_Retrieved = (int)circle_Border_Width_Numeric.Value;
            circleShape.BorderWidth = circleBorderWidth_Retrieved;
        }

        /// <summary>
        /// Handles the ValueChanged event of the polygon_Border_Width_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_Border_Width_Numeric_ValueChanged(object sender, EventArgs e)
        {
            polygonBorderWidth_Retrieved = (int)polygon_Border_Width_Numeric.Value;
            polygonShape.BorderWidth = polygonBorderWidth_Retrieved;
            
        }

        /// <summary>
        /// Handles the ValueChanged event of the pie_Border_Width_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_Border_Width_Numeric_ValueChanged(object sender, EventArgs e)
        {
            pieBorderWidth_Retrieved = (int)pie_Border_Width_Numeric.Value;
            pieShape.BorderWidth = pieBorderWidth_Retrieved;

        }



        /// <summary>
        /// Handles the Click event of the rectangle_Color control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_Color_Click(object sender, EventArgs e)
        {
            //shapeColorDialog.ShowDialog();

            

            if (shapeColorDialog.ShowDialog() == DialogResult.OK)
            {
                //rectangleShape.ShapeColor = shapeColorDialog.Color;
                rectangle_Color.BackColor = shapeColorDialog.Color;
                rectangleColor_Retrieved = shapeColorDialog.Color;

                circle_Color.BackColor = shapeColorDialog.Color;
                circleColor_Retrieved = shapeColorDialog.Color;

                pie_Color.BackColor = shapeColorDialog.Color;
                pieColor_Retrieved = shapeColorDialog.Color;

                polygon_Color.BackColor = shapeColorDialog.Color;
                polygonColor_Retrieved = shapeColorDialog.Color;

                if (rectangleShape.ColorShape == true)
                {
                    rectangleShape.ShapeColor = shapeColorDialog.Color;
                    circleShape.ShapeColor = shapeColorDialog.Color;
                    pieShape.ShapeColor = shapeColorDialog.Color;
                    polygonShape.ShapeColor = shapeColorDialog.Color;

                    //rectangleShape.ShapeColor = shapeColorDialog.Color;
                }
            }

            
        }

        /// <summary>
        /// Handles the Click event of the circle_Color control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void circle_Color_Click(object sender, EventArgs e)
        {
            //shapeColorDialog.ShowDialog();

            if (shapeColorDialog.ShowDialog() == DialogResult.OK)
            {
                rectangle_Color.BackColor = shapeColorDialog.Color;
                rectangleColor_Retrieved = shapeColorDialog.Color;

                circle_Color.BackColor = shapeColorDialog.Color;
                circleColor_Retrieved = shapeColorDialog.Color;

                pie_Color.BackColor = shapeColorDialog.Color;
                pieColor_Retrieved = shapeColorDialog.Color;

                polygon_Color.BackColor = shapeColorDialog.Color;
                polygonColor_Retrieved = shapeColorDialog.Color;

                if (circleShape.ColorShape == true)
                {
                    rectangleShape.ShapeColor = shapeColorDialog.Color;
                    circleShape.ShapeColor = shapeColorDialog.Color;
                    pieShape.ShapeColor = shapeColorDialog.Color;
                    polygonShape.ShapeColor = shapeColorDialog.Color;

                    //rectangleShape.ShapeColor = shapeColorDialog.Color;
                }
            }

            
        }

        /// <summary>
        /// Handles the Click event of the polygon_Color control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_Color_Click(object sender, EventArgs e)
        {

            if (shapeColorDialog.ShowDialog() == DialogResult.OK)
            {
                rectangle_Color.BackColor = shapeColorDialog.Color;
                rectangleColor_Retrieved = shapeColorDialog.Color;

                circle_Color.BackColor = shapeColorDialog.Color;
                circleColor_Retrieved = shapeColorDialog.Color;

                pie_Color.BackColor = shapeColorDialog.Color;
                pieColor_Retrieved = shapeColorDialog.Color;

                polygon_Color.BackColor = shapeColorDialog.Color;
                polygonColor_Retrieved = shapeColorDialog.Color;

                if (polygonShape.ColorShape == true)
                {
                    rectangleShape.ShapeColor = shapeColorDialog.Color;
                    circleShape.ShapeColor = shapeColorDialog.Color;
                    pieShape.ShapeColor = shapeColorDialog.Color;
                    polygonShape.ShapeColor = shapeColorDialog.Color;

                    //rectangleShape.ShapeColor = shapeColorDialog.Color;
                }
            }

            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();

        }

        /// <summary>
        /// Handles the Click event of the pie_Color control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_Color_Click(object sender, EventArgs e)
        {

            if (shapeColorDialog.ShowDialog() == DialogResult.OK)
            {
                rectangle_Color.BackColor = shapeColorDialog.Color;
                rectangleColor_Retrieved = shapeColorDialog.Color;

                circle_Color.BackColor = shapeColorDialog.Color;
                circleColor_Retrieved = shapeColorDialog.Color;

                pie_Color.BackColor = shapeColorDialog.Color;
                pieColor_Retrieved = shapeColorDialog.Color;

                polygon_Color.BackColor = shapeColorDialog.Color;
                polygonColor_Retrieved = shapeColorDialog.Color;

                if (pieShape.ColorShape == true)
                {
                    rectangleShape.ShapeColor = shapeColorDialog.Color;
                    circleShape.ShapeColor = shapeColorDialog.Color;
                    pieShape.ShapeColor = shapeColorDialog.Color;
                    polygonShape.ShapeColor = shapeColorDialog.Color;

                    //rectangleShape.ShapeColor = shapeColorDialog.Color;
                }
            }

            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();

        }



        /// <summary>
        /// Handles the Click event of the rectangle_BorderColor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rectangle_BorderColor_Click(object sender, EventArgs e)
        {
            //shapeColorDialog.ShowDialog();

            

            if (shapeColorDialog.ShowDialog() == DialogResult.OK)
            {
                

                rectangle_BorderColor.BackColor = shapeColorDialog.Color;
                rectangleBorderColor_Retrieved = shapeColorDialog.Color;

                circle_BorderColor.BackColor = shapeColorDialog.Color;
                circleBorderColor_Retrieved = shapeColorDialog.Color;

                pie_BorderColor.BackColor = shapeColorDialog.Color;
                pieBorderColor_Retrieved = shapeColorDialog.Color;

                polygon_BorderColor.BackColor = shapeColorDialog.Color;
                polygonBorderColor_Retrieved = shapeColorDialog.Color;

                if (rectangleShape.DrawBorder == true)
                {
                    //rectangleShape.BorderColor = rectangleBorderColor_Retrieved;

                    rectangleShape.BorderColor = shapeColorDialog.Color;
                    circleShape.BorderColor = shapeColorDialog.Color;
                    pieShape.BorderColor = shapeColorDialog.Color;
                    polygonShape.BorderColor = shapeColorDialog.Color;
                }
            }

            
        }

        /// <summary>
        /// Handles the Click event of the circle_BorderColor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void circle_BorderColor_Click(object sender, EventArgs e)
        {

            if (shapeColorDialog.ShowDialog() == DialogResult.OK)
            {
                rectangle_BorderColor.BackColor = shapeColorDialog.Color;
                rectangleBorderColor_Retrieved = shapeColorDialog.Color;

                circle_BorderColor.BackColor = shapeColorDialog.Color;
                circleBorderColor_Retrieved = shapeColorDialog.Color;

                pie_BorderColor.BackColor = shapeColorDialog.Color;
                pieBorderColor_Retrieved = shapeColorDialog.Color;

                polygon_BorderColor.BackColor = shapeColorDialog.Color;
                polygonBorderColor_Retrieved = shapeColorDialog.Color;

                if (circleShape.DrawBorder == true)
                {
                    //rectangleShape.BorderColor = rectangleBorderColor_Retrieved;

                    rectangleShape.BorderColor = shapeColorDialog.Color;
                    circleShape.BorderColor = shapeColorDialog.Color;
                    pieShape.BorderColor = shapeColorDialog.Color;
                    polygonShape.BorderColor = shapeColorDialog.Color;
                }
            }

            
        }

        /// <summary>
        /// Handles the Click event of the polygon_BorderColor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_BorderColor_Click(object sender, EventArgs e)
        {

            if (shapeColorDialog.ShowDialog() == DialogResult.OK)
            {
                rectangle_BorderColor.BackColor = shapeColorDialog.Color;
                rectangleBorderColor_Retrieved = shapeColorDialog.Color;

                circle_BorderColor.BackColor = shapeColorDialog.Color;
                circleBorderColor_Retrieved = shapeColorDialog.Color;

                pie_BorderColor.BackColor = shapeColorDialog.Color;
                pieBorderColor_Retrieved = shapeColorDialog.Color;

                polygon_BorderColor.BackColor = shapeColorDialog.Color;
                polygonBorderColor_Retrieved = shapeColorDialog.Color;

                if (polygonShape.DrawBorder == true)
                {
                    //rectangleShape.BorderColor = rectangleBorderColor_Retrieved;

                    rectangleShape.BorderColor = shapeColorDialog.Color;
                    circleShape.BorderColor = shapeColorDialog.Color;
                    pieShape.BorderColor = shapeColorDialog.Color;
                    polygonShape.BorderColor = shapeColorDialog.Color;
                }
            }

            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();

        }

        /// <summary>
        /// Handles the Click event of the pie_BorderColor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_BorderColor_Click(object sender, EventArgs e)
        {
            if (shapeColorDialog.ShowDialog() == DialogResult.OK)
            {
                rectangle_BorderColor.BackColor = shapeColorDialog.Color;
                rectangleBorderColor_Retrieved = shapeColorDialog.Color;

                circle_BorderColor.BackColor = shapeColorDialog.Color;
                circleBorderColor_Retrieved = shapeColorDialog.Color;

                pie_BorderColor.BackColor = shapeColorDialog.Color;
                pieBorderColor_Retrieved = shapeColorDialog.Color;

                polygon_BorderColor.BackColor = shapeColorDialog.Color;
                polygonBorderColor_Retrieved = shapeColorDialog.Color;

                if (pieShape.DrawBorder == true)
                {
                    //rectangleShape.BorderColor = rectangleBorderColor_Retrieved;

                    rectangleShape.BorderColor = shapeColorDialog.Color;
                    circleShape.BorderColor = shapeColorDialog.Color;
                    pieShape.BorderColor = shapeColorDialog.Color;
                    polygonShape.BorderColor = shapeColorDialog.Color;
                }
            }

            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();

        }


        /// <summary>
        /// Shapes the changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ShapeChanged(object sender, EventArgs e)
        {
            rectangle_GroupBox.Visible = false;
            circle_GroupBox.Visible = false;
            polygon_GroupBox.Visible = false;
            pie_GroupBox.Visible = false;



            if (rectangle_RadioBtn.Checked)
            {
                rectangle_GroupBox.Visible = true;

            }
            else if (circle_RadioBtn.Checked)
            {
                circle_GroupBox.Visible = true;
            }
            else if (polygon_RadioBtn.Checked)
            {
                polygon_GroupBox.Visible = true;
            }
            else if (pie_RadioBtn.Checked)
            {
                pie_GroupBox.Visible = true;
            }

            else if (none_RadioBtn.Checked)
            {
                rectangle_GroupBox.Visible = false;
                circle_GroupBox.Visible = false;
                polygon_GroupBox.Visible = false;
                pie_GroupBox.Visible = false;
            }
        }


        /// <summary>
        /// Handles the Click event of the okBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void okBtn_Click(object sender, EventArgs e)
        {

            if (rectangle_RadioBtn.Checked)
            {

                //try
                //{
                //    //shapePopulate = new ShapeInput(
                //    //    Shapes.Rectangle, 
                //    //    Color.DeepSkyBlue, 
                //    //    Color.Yellow,true,false,true, 
                //    //    rectangleCurve_Retrieved, 
                //    //    rectangleCurve_UL_Retrieved,
                //    //    rectangleCurve_UR_Retrieved,
                //    //    rectangleCurve_DL_Retrieved,
                //    //    rectangleCurve_DR_Retrieved);

                //    shapePopulate = new ShapeInput(
                //        Shapes.Rectangle,
                //        Color.DeepSkyBlue,
                //        Color.Yellow, true, false, true,
                //        10,
                //        10,
                //        10,
                //        10,
                //        10);
                //    SetControl_Rectangle_Passed_Values(shapePopulate);
                //}
                //catch (Exception exception)
                //{
                //    MessageBox.Show(exception.Message);
                //    this.Close();
                //}

                shapePopulate = new ShapeInput(
                    Shapes.Rectangle,
                    Color.DeepSkyBlue,
                    Color.Yellow,
                    1,true,10,40,40,40,40,false,true);

                SetControl_Rectangle_Passed_Values(shapePopulate);


            }

            else if (circle_RadioBtn.Checked)
            {
                //try
                //{
                //    shapePopulate = new ShapeInput(Shapes.Circle, Color.DeepSkyBlue,
                //        Color.Yellow, true, false);
                //    SetControl_Circle_Passed_Values(shapePopulate);
                //}
                //catch (Exception exception)
                //{
                //    MessageBox.Show(exception.Message);
                //    this.Close();
                //}

                shapePopulate = new ShapeInput(Shapes.Circle, Color.DeepSkyBlue,
                    Color.Yellow,1, false, true);
                SetControl_Circle_Passed_Values(shapePopulate);

            }

            else if (polygon_RadioBtn.Checked)
            {
                
                shapePopulate = new ShapeInput(Shapes.Polygon, Color.DeepSkyBlue,
                    Color.Yellow,1, 3, 90,false,true);

                SetControl_Polygon_Passed_Values(shapePopulate);
            }

            else if (pie_RadioBtn.Checked)
            {
                
                shapePopulate = new ShapeInput(Shapes.Pie, Color.DeepSkyBlue,
                    Color.Yellow,1, 3f, 90f, false,true);

                SetControl_Pie_Passed_Values(shapePopulate);

            }

            else if (none_RadioBtn.Checked)
            {
                shapePopulate = new ShapeInput(Shapes.None, Color.DeepSkyBlue,
                    Color.Yellow, 1);
            }

            //else
            //{
            //    shapePopulate = ShapeInput.Empty();
            //}

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of the cancelBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        /// <summary>
        /// Handles the Click event of the closeBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Handles the MouseEnter event of the closeBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.BackColor = Color.Red;
            closeBtn.FlatAppearance.BorderSize = 0;
        }

        /// <summary>
        /// Handles the MouseLeave event of the closeBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.BackColor = Color.FromArgb(28, 28, 28);
            closeBtn.FlatAppearance.BorderSize = 1;
        }

        /// <summary>
        /// Handles the Click event of the showSidesKnob control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void showSidesKnob_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Added();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the showAngleKnob control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void showAngleKnob_Click(object sender, EventArgs e)
        {
            PolygonAngleKnob_Added();
            PolygonSidesKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the showStartAngleKnob control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void showStartAngleKnob_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Added();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the showEndAngleKnob control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void showEndAngleKnob_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Added();
        }

        /// <summary>
        /// Handles the Enter event of the polygon_GroupBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_GroupBox_Enter(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Enter event of the pie_GroupBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_GroupBox_Enter(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the thematic1501 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void thematic1501_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the polygon_Border_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_Border_Combo_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the polygon_Colored_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_Colored_Combo_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the polygon_Border_Width_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_Border_Width_Numeric_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the polygon_Sides_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_Sides_Numeric_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the polygon_Angle_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void polygon_Angle_Numeric_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the pie_Border_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_Border_Combo_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the pie_Colored_Combo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_Colored_Combo_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the pie_Border_Width_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_Border_Width_Numeric_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the pie_StartAngle_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_StartAngle_Numeric_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }

        /// <summary>
        /// Handles the Click event of the pie_EndAngle_Numeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pie_EndAngle_Numeric_Click(object sender, EventArgs e)
        {
            PolygonSidesKnob_Removed();
            PolygonAngleKnob_Removed();
            PieStartKnob_Removed();
            PieEndKnob_Removed();
        }
    }

}
