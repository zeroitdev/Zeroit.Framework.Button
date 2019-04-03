// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ShapeInput.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using Zeroit.Framework.Button.Editor;

namespace Zeroit.Framework.Button
{

    /// <summary>
    /// A class representing a circular or polygonal shape.
    /// </summary>
    [TypeConverter(typeof(ShapeInputConverter))]
    [Editor(typeof(ShapeInputEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [Serializable]
    public class ShapeInput
    {

        #region Private Fields

        /// <summary>
        /// The color shape
        /// </summary>
        private bool colorShape = true;
        /// <summary>
        /// The draw border
        /// </summary>
        private bool drawBorder = true;
        /// <summary>
        /// The rounding
        /// </summary>
        private bool rounding = false;

        /// <summary>
        /// The curve
        /// </summary>
        private int curve = 10;
        /// <summary>
        /// The border width
        /// </summary>
        private int borderWidth = 1;

        /// <summary>
        /// The upper left curve
        /// </summary>
        private int upperLeftCurve = 10;
        /// <summary>
        /// The upper right curve
        /// </summary>
        private int upperRightCurve = 10;
        /// <summary>
        /// Down left curve
        /// </summary>
        private int downLeftCurve = 10;
        /// <summary>
        /// Down right curve
        /// </summary>
        private int downRightCurve = 10;

        /// <summary>
        /// The start angle
        /// </summary>
        private float startAngle = 0f;
        /// <summary>
        /// The end angle
        /// </summary>
        private float endAngle = 90f;

        /// <summary>
        /// The shape color
        /// </summary>
        private Color shapeColor = Color.Yellow;
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.Black;

        /// <summary>
        /// The shapes
        /// </summary>
        public Shapes _shapes = Shapes.Rectangle;

        /// <summary>
        /// The sides
        /// </summary>
        private int sides = 3;
        /// <summary>
        /// The radius
        /// </summary>
        private int radius = 10;
        /// <summary>
        /// The starting angle
        /// </summary>
        private int startingAngle = 90;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the color of the shape.
        /// </summary>
        /// <value>The color of the shape.</value>
        public Color ShapeColor
        {
            get { return shapeColor; }
            set
            {
                shapeColor = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                
            }
        }


        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>The start angle.</value>
        public float StartAngle
        {
            get { return startAngle; }
            set
            {
                startAngle = value;
                
            }
        }


        /// <summary>
        /// Gets or sets the end angle.
        /// </summary>
        /// <value>The end angle.</value>
        public float EndAngle
        {
            get { return endAngle; }
            set
            {
                endAngle = value;
                
            }
        }


        /// <summary>
        /// Gets or sets the curve.
        /// </summary>
        /// <value>The curve.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Value must be more than 1</exception>
        public int Curve
        {
            get { return curve; }
            set
            {
                if (value > 0)
                {
                    upperLeftCurve = value;
                    upperRightCurve = value;
                    downLeftCurve = value;
                    downRightCurve = value;
                }

                if (value < 1)
                {
                    value = 1;
                    throw new ArgumentOutOfRangeException("", "Value must be more than 1");
                }

                curve = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the upper left curve.
        /// </summary>
        /// <value>The upper left curve.</value>
        public int UpperLeftCurve
        {
            get { return upperLeftCurve; }
            set
            {
                upperLeftCurve = value;
                
            }
        }


        /// <summary>
        /// Gets or sets the upper right curve.
        /// </summary>
        /// <value>The upper right curve.</value>
        public int UpperRightCurve
        {
            get { return upperRightCurve; }
            set
            {
                upperRightCurve = value;
                
            }
        }


        /// <summary>
        /// Gets or sets down left curve.
        /// </summary>
        /// <value>Down left curve.</value>
        public int DownLeftCurve
        {
            get { return downLeftCurve; }
            set
            {
                downLeftCurve = value;
                
            }
        }


        /// <summary>
        /// Gets or sets down right curve.
        /// </summary>
        /// <value>Down right curve.</value>
        public int DownRightCurve
        {
            get { return downRightCurve; }
            set
            {
                downRightCurve = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [color shape].
        /// </summary>
        /// <value><c>true</c> if [color shape]; otherwise, <c>false</c>.</value>
        public bool ColorShape
        {
            get { return colorShape; }
            set
            {
                colorShape = value;
                
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw border].
        /// </summary>
        /// <value><c>true</c> if [draw border]; otherwise, <c>false</c>.</value>
        public bool DrawBorder
        {
            get
            {
                return drawBorder;

            }
            set
            {
                drawBorder = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public Shapes Shape
        {
            get { return _shapes; }
            set
            {
                _shapes = value;
                
                
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ShapeInput"/> is rounding.
        /// </summary>
        /// <value><c>true</c> if rounding; otherwise, <c>false</c>.</value>
        public bool Rounding
        {
            get { return rounding; }
            set
            {
                rounding = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the polygon sides.
        /// </summary>
        /// <value>The polygon sides.</value>
        public Int32 PolygonSides
        {
            get { return sides; }
            set
            {
                
                sides = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the polygon radius.
        /// </summary>
        /// <value>The polygon radius.</value>
        public Int32 PolygonRadius
        {
            get { return radius; }
            set
            {
                radius = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the polygon starting angle.
        /// </summary>
        /// <value>The polygon starting angle.</value>
        public Int32 PolygonStartingAngle
        {
            get { return startingAngle; }
            set
            {
                startingAngle = value;
                
            }
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>ShapeInput.</returns>
        public ShapeInput Clone()
        {
            return new ShapeInput(_shapes);
        }


        /// <summary>
        /// Empties this instance.
        /// </summary>
        /// <returns>ShapeInput.</returns>
        public static ShapeInput Empty()
        {
            return new ShapeInput();
        }



        #endregion

        #region Constructors

        // Internal constructor 
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeInput"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public ShapeInput(Shapes type)
        {
            this._shapes = type;
        }


        /// <summary>
        /// Constructor for no fill.
        /// </summary>
        public ShapeInput() : this(Shapes.None) /* gradientColors */
        {
        }

        /// <summary>
        /// Constructor for none fill.
        /// </summary>
        /// <param name="None">The none.</param>
        /// <param name="shapeColor">Color of the shape.</param>
        /// <param name="borderColor">Color of the border.</param>
        /// <param name="borderWidth">Width of the border.</param>
        public ShapeInput(Shapes None, Color shapeColor, Color borderColor, int borderWidth) : 
            this(Shapes.None) /* gradientColors */
        {
            this._shapes = None;
            this.shapeColor = shapeColor;
            this.borderColor = borderColor;
            this.borderWidth = borderWidth;
            
        }

        /// <summary>
        /// Constructor for Rectangle.
        /// </summary>
        /// <param name="Rectangle">The rectangle.</param>
        /// <param name="borderColor">Color of the border.</param>
        /// <param name="shapeColor">Color of the shape.</param>
        /// <param name="borderWidth">Width of the border.</param>
        /// <param name="rounding">if set to <c>true</c> [rounding].</param>
        /// <param name="curve">The curve.</param>
        /// <param name="upperLeftCurve">The upper left curve.</param>
        /// <param name="upperRightCurve">The upper right curve.</param>
        /// <param name="downLeftCurve">Down left curve.</param>
        /// <param name="downRightCurve">Down right curve.</param>
        /// <param name="colorShape">if set to <c>true</c> [color shape].</param>
        /// <param name="drawborder">if set to <c>true</c> [drawborder].</param>
        public ShapeInput(Shapes Rectangle,
            Color borderColor, Color shapeColor,
            int borderWidth,bool rounding,
            int curve, int upperLeftCurve, int upperRightCurve, int downLeftCurve, int downRightCurve,
            bool colorShape, bool drawborder) : 
            this(Shapes.Rectangle)
        {
            this._shapes = Rectangle;
            this.borderColor = borderColor;
            this.shapeColor = shapeColor;
            this.rounding = rounding;
            this.colorShape = colorShape;
            this.upperLeftCurve = upperLeftCurve;
            this.upperRightCurve = upperRightCurve;
            this.downLeftCurve = downLeftCurve;
            this.downRightCurve = downRightCurve;
            this.drawBorder = drawborder;
            this.curve = curve;
            this.borderWidth = borderWidth;

        }


        /// <summary>
        /// Constructor for Circle.
        /// </summary>
        /// <param name="Circle">The circle.</param>
        /// <param name="borderColor">Color of the border.</param>
        /// <param name="shapeColor">Color of the shape.</param>
        /// <param name="borderWidth">Width of the border.</param>
        /// <param name="colorShape">if set to <c>true</c> [color shape].</param>
        /// <param name="drawBorder">if set to <c>true</c> [draw border].</param>
        public ShapeInput(Shapes Circle, Color borderColor, Color shapeColor, 
            int borderWidth, bool colorShape, bool drawBorder) : 
            this(Shapes.Circle)
        {
            this._shapes = Circle;
            this.borderColor = borderColor;
            this.shapeColor = shapeColor;
            this.borderWidth = borderWidth;
            this.colorShape = colorShape;
            this.drawBorder = drawBorder;
            
        }

        /// <summary>
        /// Constructor for Polygon.
        /// </summary>
        /// <param name="Polygon">The polygon.</param>
        /// <param name="borderColor">Color of the border.</param>
        /// <param name="shapeColor">Color of the shape.</param>
        /// <param name="borderWidth">Width of the border.</param>
        /// <param name="sides">The sides.</param>
        /// <param name="startingAngle">The starting angle.</param>
        /// <param name="colorShape">if set to <c>true</c> [color shape].</param>
        /// <param name="drawBorder">if set to <c>true</c> [draw border].</param>
        public ShapeInput(Shapes Polygon, Color borderColor, Color shapeColor, 
            int borderWidth, int sides, int startingAngle, bool colorShape, bool drawBorder) : 
            this(Shapes.Polygon)
        {
            this._shapes = Polygon;
            this.borderColor = borderColor;
            this.shapeColor = shapeColor;
            this.borderWidth = borderWidth;
            this.sides = sides;
            this.startingAngle = startingAngle;
            this.colorShape = colorShape;
            this.drawBorder = drawBorder;
        }

        /// <summary>
        /// Constructor for Pie.
        /// </summary>
        /// <param name="Pie">The pie.</param>
        /// <param name="borderColor">Color of the border.</param>
        /// <param name="shapeColor">Color of the shape.</param>
        /// <param name="borderWidth">Width of the border.</param>
        /// <param name="startangle">The startangle.</param>
        /// <param name="endangle">The endangle.</param>
        /// <param name="colorShape">if set to <c>true</c> [color shape].</param>
        /// <param name="drawBorder">if set to <c>true</c> [draw border].</param>
        public ShapeInput(Shapes Pie, Color borderColor, Color shapeColor, 
            int borderWidth, float startangle, float endangle, bool colorShape, bool drawBorder) : 
            this(Shapes.Pie)
        {
            this._shapes = Pie;
            this.borderColor = borderColor;
            this.shapeColor = shapeColor;
            this.borderWidth = borderWidth;
            this.startAngle = startangle;
            this.endAngle = endangle;
            this.colorShape = colorShape;
            this.drawBorder = drawBorder;
        }


        #endregion

        #region Editor Brush

        /// <summary>
        /// Gets the UI type editor pen.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <returns>Pen.</returns>
        internal Pen GetUITypeEditorPen(Rectangle bounds)
        {
            return GetPen(bounds);
        }

        /// <summary>
        /// Get <c>Brush</c> for this fill.
        /// </summary>
        /// <param name="rect">Rectangle area to which fill is to be applied.</param>
        /// <returns>Brush.</returns>
        /// <remarks>The <c>rect</c> parameter only affects the brush if <c>FillerType</c> is <c>LinearGradient</c> or <c>PathGradient</c>.
        /// <para>
        /// The caller is responsible for disposing of the returned brush.
        /// </para></remarks>
        public Pen GetPen(Rectangle rect)
        {
            return GetPen(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
        }

        /// <summary>
        /// Get <c>Brush</c> for this fill.
        /// </summary>
        /// <param name="rect">Rectangle area to which fill is to be applied.</param>
        /// <returns>Brush.</returns>
        /// <remarks>The <c>rect</c> parameter only affects the brush if <c>FillerType</c> is <c>LinearGradient</c> or <c>PathGradient</c>.
        /// <para>
        /// The caller is responsible for disposing of the returned brush.
        /// </para></remarks>
        public Pen GetPen(RectangleF rect)
        {
            if (Shape == Shapes.Rectangle)
            {
                return new Pen(BorderColor);
            }

            else if (Shape == Shapes.Circle)
            {
                return new Pen(BorderColor);
            }

            else if (Shape == Shapes.Pie)
            {
                return new Pen(BorderColor);
            }
            else if (Shape == Shapes.Polygon)
            {
                return new Pen(BorderColor);
            }

            return null;
        }



        /// <summary>
        /// Gets the UI type editor brush.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <returns>Brush.</returns>
        internal Brush GetUITypeEditorBrush(Rectangle bounds)
        {
            return GetBrush(bounds);
        }

        /// <summary>
        /// Get <c>Brush</c> for this fill.
        /// </summary>
        /// <param name="rect">Rectangle area to which fill is to be applied.</param>
        /// <returns>Brush.</returns>
        /// <remarks>The <c>rect</c> parameter only affects the brush if <c>FillerType</c> is <c>LinearGradient</c> or <c>PathGradient</c>.
        /// <para>
        /// The caller is responsible for disposing of the returned brush.
        /// </para></remarks>
        public Brush GetBrush(Rectangle rect)
        {
            return GetBrush(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
        }

        /// <summary>
        /// Get <c>Brush</c> for this fill.
        /// </summary>
        /// <param name="rect">Rectangle area to which fill is to be applied.</param>
        /// <returns>Brush.</returns>
        /// <remarks>The <c>rect</c> parameter only affects the brush if <c>FillerType</c> is <c>LinearGradient</c> or <c>PathGradient</c>.
        /// <para>
        /// The caller is responsible for disposing of the returned brush.
        /// </para></remarks>
        public Brush GetBrush(RectangleF rect)
        {
            if (Shape == Shapes.Rectangle)
            {
                return new SolidBrush(ShapeColor);
            }
            else if (Shape == Shapes.Circle)
            {
                return new SolidBrush(ShapeColor);
            }
            else if (Shape == Shapes.Pie)
            {
                return new SolidBrush(ShapeColor);
            }
            else if (Shape == Shapes.Polygon)
            {
                return new SolidBrush(ShapeColor);
            }

            return null;
        }

        #endregion

    }
}
