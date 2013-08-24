using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMAControls
{
    public partial class ExtendedButton : UserControl
    {
        public ExtendedButton()
        {
            InitializeComponent();
            //DataContext = this;
        }

        #region TextSource
        public static readonly DependencyProperty TextSourceProperty = DependencyProperty.Register(
            "TextSource",
            typeof(string),
            typeof(ExtendedButton),
            new FrameworkPropertyMetadata(String.Empty,OnTextSourceChanged));


        private static void OnTextSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var myBinding = new Binding
            {
                Mode = BindingMode.OneWay,
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(e.Property),
            };

            BindingOperations.SetBinding(d, ExtendedTextBlock.TranslationKeyProperty, myBinding);
        }

        public string TextSource
        {
            get
            {
                return (string)GetValue(TextSourceProperty);
            }
            set
            {
                SetValue(TextSourceProperty, value);
            }
        }
        #endregion

        #region IconSource
        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register(
            "IconSource",
            typeof(ImageSource),
            typeof(ExtendedButton),
            new FrameworkPropertyMetadata(default(ImageSource), OnIconSourceChanged));


        private static void OnIconSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var myBinding = new Binding
            {
                Mode = BindingMode.OneWay,
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(e.Property),
            };

            BindingOperations.SetBinding(d, Image.SourceProperty, myBinding);
        }

        public ImageSource IconSource
        {
            get
            {
                return (ImageSource)GetValue(IconSourceProperty);
            }
            set
            {
                SetValue(IconSourceProperty, value);
            }
        }
        #endregion

        #region Command

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
          "Command",
          typeof(ICommand),
          typeof(ExtendedButton),
          new UIPropertyMetadata(null));


        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var myBinding = new Binding
            {
                Mode = BindingMode.OneWay,
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(e.Property),
            };

            BindingOperations.SetBinding(d, Button.CommandProperty, myBinding);
        }

        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }
        #endregion
    }
}

