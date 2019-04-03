// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ShapeInputConverter.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace Zeroit.Framework.Button
{


    /// <summary>
    /// Class ShapeInputConverter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
    public class ShapeInputConverter : TypeConverter
    {

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        // This code allows the designer to generate the Shape constructor

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
            
                if (destinationType == typeof(string))
                {
                    // Display string in designer
                    return "(Customize)";
                }

                else if (destinationType == typeof(InstanceDescriptor) && value is ShapeInput)
                {
                    ShapeInput shapeInput = (ShapeInput)value;

                    switch (shapeInput.Shape)
                    {
                        case Shapes.None:
                            ConstructorInfo ctorNone = typeof(ShapeInput).GetConstructor(new Type[] {
                                typeof(Shapes),
                                typeof(Color),
                                typeof(Color),
                                typeof(int)
                            });
                            if (ctorNone != null)
                            {
                                return new InstanceDescriptor(ctorNone, new object[] {
                                    shapeInput.Shape,
                                    shapeInput.ShapeColor,
                                    shapeInput.BorderColor,
                                    shapeInput.BorderWidth,
                                    
                                });
                            }

                            break;
                        case Shapes.Rectangle:
                            ConstructorInfo ctorRect = typeof(ShapeInput).GetConstructor(new Type[]
                            {
                                typeof(Shapes),
                                typeof(Color),
                                typeof(Color),
                                typeof(int),
                                typeof(bool),
                                typeof(int),
                                typeof(int),
                                typeof(int),
                                typeof(int),
                                typeof(int),
                                typeof(bool),
                                typeof(bool)


                            });

                            if (ctorRect != null)
                            {
                                return new InstanceDescriptor(ctorRect, new object[] {
                                    shapeInput.Shape,
                                    shapeInput.BorderColor,
                                    shapeInput.ShapeColor,
                                    shapeInput.BorderWidth,
                                    shapeInput.Rounding,
                                    shapeInput.Curve,
                                    shapeInput.UpperLeftCurve,
                                    shapeInput.UpperRightCurve,
                                    shapeInput.DownLeftCurve,
                                    shapeInput.DownRightCurve,
                                    shapeInput.ColorShape,
                                    shapeInput.DrawBorder,

                                });
                            }

                            break;
                        case Shapes.Circle:

                            ConstructorInfo ctorCirc = typeof(ShapeInput).GetConstructor(new Type[] {
                                typeof(Shapes),
                                typeof(Color),
                                typeof(Color),
                                typeof(int),
                                typeof(bool),
                                typeof(bool),
                            });

                            if (ctorCirc != null)
                            {
                                return new InstanceDescriptor(ctorCirc, new object[] {
                                    shapeInput.Shape,
                                    shapeInput.BorderColor,
                                    shapeInput.ShapeColor,
                                    shapeInput.BorderWidth,
                                    shapeInput.ColorShape,
                                    shapeInput.DrawBorder
                                });
                            }

                            break;
                        case Shapes.Polygon:

                            ConstructorInfo ctorPoly = typeof(ShapeInput).GetConstructor(new Type[] {
                                typeof(Shapes),
                                typeof(Color),
                                typeof(Color),
                                typeof(int),
                                typeof(int),
                                typeof(int),
                                typeof(bool),
                                typeof(bool),
                            });
                            if (ctorPoly != null)
                            {
                                return new InstanceDescriptor(ctorPoly, new object[] {
                                    shapeInput.Shape,
                                    shapeInput.BorderColor,
                                    shapeInput.ShapeColor,
                                    shapeInput.BorderWidth,
                                    shapeInput.PolygonSides,
                                    shapeInput.PolygonStartingAngle,
                                    shapeInput.ColorShape,
                                    shapeInput.DrawBorder,
                                });
                            }

                            break;
                        case Shapes.Pie:

                            ConstructorInfo ctorPie = typeof(ShapeInput).GetConstructor(new Type[] {
                                typeof(Shapes),
                                typeof(Color),
                                typeof(Color),
                                typeof(int),
                                typeof(float),
                                typeof(float),
                                typeof(bool),
                                typeof(bool)

                            });

                            if (ctorPie != null)
                            {
                                return new InstanceDescriptor(ctorPie, new object[] {
                                    shapeInput.Shape,
                                    shapeInput.BorderColor,
                                    shapeInput.ShapeColor,
                                    shapeInput.BorderWidth,
                                    shapeInput.StartAngle,
                                    shapeInput.EndAngle,
                                    shapeInput.ColorShape,
                                    shapeInput.DrawBorder
                                });
                            }

                            break;
                        default:
                            ConstructorInfo ctor = typeof(ShapeInput).GetConstructor(Type.EmptyTypes);
                            if (ctor != null)
                            {
                                return new InstanceDescriptor(ctor, null);
                            }
                            break;
                    }
                    
                }
            
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

}
