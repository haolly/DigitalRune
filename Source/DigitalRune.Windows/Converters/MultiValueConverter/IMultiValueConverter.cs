﻿// DigitalRune Engine - Copyright (C) DigitalRune GmbH
// This file is subject to the terms and conditions defined in
// file 'LICENSE.TXT', which is part of this source code package.

using System;
using System.Globalization;
using System.Windows;


namespace DigitalRune.Windows
{
  /// <summary>
  /// Provides a way to apply custom logic in a MultiBinding. 
  /// </summary>
  /// <remarks>
  /// (This is a reproduction of the WPF IMultiValueConverter for Silverlight, 
  /// see http://msdn.microsoft.com/en-us/library/system.windows.data.imultivalueconverter.aspx).
  /// </remarks>
  /// <example>
  /// Here is an usage example of a multi value converter:
  /// <code lang="xaml">
  /// <![CDATA[
  /// <TextBlock>
  ///   <dr:BindingHelper.MultiBindings>
  ///     <dr:MultiBindings>
  ///       <dr:MultiBinding TargetProperty="Text" Converter="{StaticResource FormattingConverter}">
  ///         <dr:BindingCollection>
  ///           <Binding Path="Strings.WidthLabel" Source="{StaticResource LocalizedResources}"/>                            
  ///           <Binding Path="Width"/>
  ///         </dr:BindingCollection>
  ///       </dr:MultiBinding>              
  ///     </dr:MultiBindings>  
  ///  </dr:BindingHelper.MultiBindings>
  /// </TextBlock>
  /// ]]>
  /// </code>
  /// </example>
  public interface IMultiValueConverter
  {
    /// <summary>
    /// Converts source values to a value for the binding target. The data binding engine calls this
    /// method when it propagates the values from source bindings to the binding target.
    /// </summary>
    /// <param name="values">
    /// The array of values that the source bindings in the <see cref="MultiBinding"/> produces. The
    /// value <see cref="DependencyProperty.UnsetValue"/> indicates that the source binding has no
    /// value to provide for conversion. 
    /// </param>
    /// <param name="targetType">
    /// The type of the binding target property.
    /// </param>
    /// <param name="parameter">
    /// The converter parameter to use.
    /// </param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>
    /// The value to be passed to the target dependency property.
    /// </returns>
    object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

    /// <summary>
    /// Converts a binding target value to the source binding values.
    /// </summary>
    /// <param name="value">
    /// The value that the binding target produces.
    /// </param>
    /// <param name="targetTypes">
    /// The array of types to convert to. The array length indicates the number and types of values 
    /// that are suggested for the method to return.
    /// </param>
    /// <param name="parameter">
    /// The converter parameter to use.
    /// </param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>
    /// An array of values that have been converted from the target value back to the source values.
    /// </returns>
    object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);
  }
}
