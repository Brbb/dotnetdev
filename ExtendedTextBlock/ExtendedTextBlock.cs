using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Translator;

namespace IMAControls
{
    public class ExtendedTextBlock : TextBlock
    {
        /// <summary>
        ///   Identifies the PlaceholderText dependency property.
        /// </summary>
        public static readonly DependencyProperty TranslationKeyProperty = DependencyProperty.Register(
            "TranslationKey",
            typeof(string),
            typeof(ExtendedTextBlock),
            new FrameworkPropertyMetadata(string.Empty, OnTranslationKeyChanged));

        
        private static void OnTranslationKeyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var myBinding = new Binding
            {
                Mode = BindingMode.OneWay,
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(e.Property),                
            };
            
            BindingOperations.SetBinding(d, ExtendedTextBlock.TextProperty, myBinding);
            
            string translationKeyValue = String.Empty;
            if (e.NewValue != null)
                translationKeyValue = Convert.ToString(e.NewValue);

            if (!String.IsNullOrEmpty(translationKeyValue))
                d.SetValue(TextProperty, translationKeyValue.Translate());
            else 
            {
                Debug.WriteLine(String.Format("Empty translation key:{0}", e.NewValue));
            }
        }

        /// <summary>
        ///   Gets or sets the placeholder text to be shown when text box has no text and is not in focus. This is a dependency property.
        /// </summary>
        public string TranslationKey
        {
            get
            {
                return (string)GetValue(TranslationKeyProperty);
            }
            set
            {
                SetValue(TranslationKeyProperty, value);
            }
        }
    }
}
