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
using FormulaChecker.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void setCursorPosition(string insertText)
        {
            var selectionIndex = textBoxFormula.SelectionStart;
            textBoxFormula.Text = textBoxFormula.Text.Insert(selectionIndex, insertText);
            textBoxFormula.SelectionStart = selectionIndex + insertText.Length;
            textBoxFormula.Focus();
        }

        private void andSymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u2227";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            setCursorPosition(insertText);
            
        }

        private void orSymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u2228";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            setCursorPosition(insertText);

        }

             private void leftImplySymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u21d0";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            setCursorPosition(insertText);
        }

        private void rightImplySymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u21d2";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            setCursorPosition(insertText);
        }

        private void eqSymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u21d4";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            setCursorPosition(insertText);
        }

        private void negationSymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u00AC";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            setCursorPosition(insertText);
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxFormula.Text = "";
        }

        private void textBoxFormula_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (textBoxFormula.Text == "Wpisz formułę")
            {
                textBoxFormula.Text = "";
            }
        }

        private void checkExpression(String expression)
        {
            Lexer lexer = new Lexer(expression);
            Interpreter interpreter = new Interpreter(lexer);

            string msgtext;
            bool result = interpreter.checkIfValid();
            if (result)
            {
                msgtext = "Zadana formuła jest poprawna";
            }
            else
            {
                msgtext = "Zadana formuła nie jest poprawna";
            }
            MessageBox.Show(msgtext);


        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {

            if(textBoxFormula.Text == "")
            {
                MessageBox.Show("Podaj formułę!");
            }
            else {
                checkExpression(textBoxFormula.Text);
            }
        }

 
    }
}
