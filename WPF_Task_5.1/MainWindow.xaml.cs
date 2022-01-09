using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPF_Task_5._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Выбор стиля шрифта
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textbox != null)
                textbox.FontFamily = new FontFamily(fontName);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e) // Выбор размера шрифта
        {
            int fontSize = Convert.ToInt32(((sender as ComboBox).SelectedItem as TextBlock).Text);
            if (textbox != null)
                textbox.FontSize = fontSize;
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Bold text
        {
            if (textbox.FontWeight == FontWeights.Bold)
                textbox.FontWeight = FontWeights.Light;
            else
                textbox.FontWeight = FontWeights.Bold;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // Italic text
        {
            if (textbox.FontStyle == FontStyles.Italic)
                textbox.FontStyle = FontStyles.Normal;
            else
                textbox.FontStyle = FontStyles.Italic;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // Underlined text
        {
            if (textbox.TextDecorations == TextDecorations.Underline)
                textbox.TextDecorations = null;
            else
                textbox.TextDecorations = TextDecorations.Underline;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) // Выбор цвета текста - черный
        {
            if (textbox != null)
                textbox.Foreground = Brushes.Black;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e) // Выбор цвета текста - красный
        {
            if (textbox != null)
                textbox.Foreground = Brushes.Red;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) // Выбор пункта меню "Файл -> Открыть"
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                textbox.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) // Выбор пункта меню "Файл -> Сохранить"
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, textbox.Text);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e) // Выбор пункта меню "Файл -> Закрыть"
        {
            if (textbox.Text.Length != 0)
            {
                MessageBoxResult result = MessageBox.Show("Сохранить изменения?", "Выход", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == true)
                        File.WriteAllText(saveFileDialog.FileName, textbox.Text);
                    Application.Current.Shutdown();
                }
                else if (result == MessageBoxResult.No)
                {
                    Application.Current.Shutdown();
                }
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e) // Выбор пункта меню "Правка -> Шрифт"
        {
            WindowFonts windowFonts = new WindowFonts();
            windowFonts.ShowDialog();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e) // Выбор пункта меню "Справка"
        {
            MessageBox.Show("Текстовый редактор. Версия 1.01");

        }
    }

}
