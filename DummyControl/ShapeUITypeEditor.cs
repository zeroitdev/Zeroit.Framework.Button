// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ShapeUITypeEditor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;


namespace Zeroit.Framework.Button.Editor
{
    /// <summary>
    /// The <c>UITypeEditor</c> derived class which indicates how a <c>Filler</c>
    /// object can be edited directly from Visual Studio Designer.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    /// <remarks>Note that this class is <b>NOT</b> meant to be invoked directly</remarks>
    public class ShapePopulateEditor : System.Drawing.Design.UITypeEditor
    {
        /// <summary>
        /// Gets the editor style used by the <c>EditValue</c> method.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <returns><c>UITypeEditorEditStyle.Modal</c></returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        /// Creates and displays a <c>FillerEditorDialog</c> dialog if <c>value</c> is a <c>Filler</c>.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <param name="provider">An IServiceProvider through which editing services may be obtained.</param>
        /// <param name="value">An instance of <c>Filler</c> being edited.</param>
        /// <returns>The new value of the <c>Filler</c> being edited.</returns>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context,
            System.IServiceProvider provider,
            object value)
        {
            if (value is ShapePopulate)
            {
                ShapeDialog dialog = new ShapeDialog((ShapePopulate)value);
                //dialog.Show();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.ShapePopulate;
                }
            }
            return value;
        }

        /// <summary>
        /// Indicates that painting is supported.
        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <returns><c>true</c>.</returns>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Paint a representation of the simple filler (usually in designer).
        /// </summary>
        /// <param name="e">A <c>PaintValueEventArgs</c> that indicates what to paint and where to paint it.</param>
        public override void PaintValue(PaintValueEventArgs e)
        {

            //e.Graphics.FillRectangle(new SolidBrush(), e.Bounds /*r*/);

            if (e.Value is ShapePopulate)
            {
                Shapes shapeType = ((ShapePopulate) e.Value).ShapeType;
                Brush br = ((ShapePopulate)e.Value).GetUITypeEditorBrush(e.Bounds);
                Pen pn = ((ShapePopulate)e.Value).GetUITypeEditorPen(e.Bounds);
                bool drawBorder = ((ShapePopulate) e.Value).DrawBorder;
                bool colored = ((ShapePopulate)e.Value).ColorShape;

                float startAngle = ((ShapePopulate) e.Value).StartAngle;
                float sweepAngle = ((ShapePopulate)e.Value).EndAngle;

                Point center = new Point(e.Bounds.Width/2, e.Bounds.Height/2);

                Point[] Poly1 = GetPolygonPoints
                (
                    ((ShapePopulate)e.Value).PolygonSides,
                    8,
                    ((ShapePopulate)e.Value).PolygonStartingAngle,
                    center
                );

                if (br != null && pn !=null)
                {
                    if (shapeType == Shapes.Rectangle)
                    {
                        //if(colored)
                        //e.Graphics.FillRectangle(br, e.Bounds /*r*/);

                        //if(drawBorder)
                        //    e.Graphics.DrawRectangle(pn, e.Bounds /*r*/);

                        if (colored == true && drawBorder == false)
                        {
                            e.Graphics.FillRectangle(br, e.Bounds.X +1 , e.Bounds.Y +1 ,e.Bounds.Width - 3,e.Bounds.Height - 3 /*r*/);

                        }
                        else if (drawBorder == true && colored == false)
                        {
                            e.Graphics.DrawRectangle(pn, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width , e.Bounds.Height - 3 /*r*/);

                        }
                        else if (drawBorder == true && colored == true)
                        {
                            e.Graphics.FillRectangle(br, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/);
                            e.Graphics.DrawRectangle(pn, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/);
                        }
                        else
                        {

                            e.Graphics.DrawRectangle(pn, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/);

                        }

                    }
                    else if (shapeType == Shapes.Circle)
                    {
                        if (colored == true && drawBorder == false)
                        {
                            e.Graphics.FillEllipse(br, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/);

                        }
                        else if (drawBorder == true && colored == false)
                        {
                            e.Graphics.DrawEllipse(pn, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/);

                        }
                        else if (drawBorder == true && colored == true)
                        {
                            e.Graphics.FillEllipse(br, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/);
                            e.Graphics.DrawEllipse(pn, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/);
                        }
                        else
                        {

                            e.Graphics.DrawEllipse(pn, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/);

                        }


                    }
                    else if (shapeType == Shapes.Pie)
                    {
                        //if (colored)
                        //{
                        //    e.Graphics.FillPie(br, e.Bounds /*r*/, startAngle, sweepAngle);
                        //}
                        //else
                        //{
                            
                        //        e.Graphics.DrawPie(pn, e.Bounds /*r*/, startAngle, sweepAngle);

                        //}

                        //if (drawBorder)
                        //    e.Graphics.DrawPie(pn, e.Bounds /*r*/, startAngle, sweepAngle);


                        if (colored == true && drawBorder == false)
                        {
                            e.Graphics.FillPie(br, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/, startAngle, sweepAngle);

                        }
                        else if (drawBorder == true && colored == false)
                        {
                            e.Graphics.DrawPie(pn, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/, startAngle, sweepAngle);


                        }
                        else if (drawBorder == true && colored == true)
                        {
                            e.Graphics.FillPie(br, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/, startAngle, sweepAngle);
                            e.Graphics.DrawPie(pn, e.Bounds.X +1 , e.Bounds.Y +1 , e.Bounds.Width - 3, e.Bounds.Height - 3 /*r*/, startAngle, sweepAngle);

                        }
                        else
                        {

                            e.Graphics.DrawPie(pn, e.Bounds /*r*/, startAngle, sweepAngle);

                        }

                    }
                    else
                    {
                        //if (colored)
                        //    e.Graphics.FillPolygon(br, Poly1);

                        //if (drawBorder)
                        //    e.Graphics.DrawPolygon(pn, Poly1);

                        if (colored == true && drawBorder == false)
                        {
                            e.Graphics.FillPolygon(br, Poly1);

                        }
                        else if (drawBorder == true && colored == false)
                        {
                            e.Graphics.DrawPolygon(pn, Poly1);
                        }
                        else if (drawBorder == true && colored == true)
                        {
                            e.Graphics.FillPolygon(br, Poly1);
                            e.Graphics.DrawPolygon(pn, Poly1);
                        }
                        else
                        {
                            e.Graphics.DrawPolygon(pn, Poly1);
                        }

                    }

                }
            }
            


        }

        /// <summary>
        /// Return an array of 10 points to be used in a Draw- or FillPolygon method
        /// </summary>
        /// <param name="sides">The sides.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="startingAngle">The starting angle.</param>
        /// <param name="center">The center.</param>
        /// <returns>Array of 10 PointF structures</returns>
        /// <exception cref="System.ArgumentException">Polygon must have 3 sides or more.</exception>
        private static Point[] GetPolygonPoints(int sides, int radius, int startingAngle, Point center)
        {


            if (sides < 3)
                throw new ArgumentException("Polygon must have 3 sides or more.");

            List<Point> points = new List<Point>();
            float step = 360.0f / sides;

            float angle = startingAngle; //starting angle
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a circle
            {
                points.Add(DegreesToXY(angle, radius, center));
                angle += step;
            }

            return points.ToArray();
        }

        /// <summary>
        /// Degrees to X and Y
        /// </summary>
        /// <param name="degrees">Set degrees</param>
        /// <param name="radius">Set radius</param>
        /// <param name="origin">Set origin</param>
        /// <returns>Point.</returns>
        private static Point DegreesToXY(float degrees, float radius, Point origin)
        {
            Point xy = new Point();
            double radians = degrees * Math.PI / 180.0;

            xy.X = (int)(Math.Cos(radians) * radius + origin.X);
            xy.Y = (int)(Math.Sin(-radians) * radius + origin.Y);

            return xy;
        }
    }
}
