using System;
using Microsoft.Maui.Controls;

namespace SimpleCalculator
{
    public partial class MainPage : ContentPage
    {
        string currentEntry = "";
        double firstNumber = 0;
        string operation = "";
        bool isNewEntry = true;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string text = button.Text;

                if (double.TryParse(text, out double num) || text == ".")
                {
                    if (isNewEntry)
                    {
                        currentEntry = "";
                        isNewEntry = false;
                    }

                    if (text == "." && currentEntry.Contains("."))
                        return;

                    currentEntry += text;
                    txtDisplay.Text = currentEntry;
                }
                else
                {
                    switch (text)
                    {
                        case "C":
                            currentEntry = "";
                            firstNumber = 0;
                            operation = "";
                            txtDisplay.Text = "0";
                            isNewEntry = true;
                            break;

                        case "±":
                            if (double.TryParse(currentEntry, out double neg))
                            {
                                neg = -neg;
                                currentEntry = neg.ToString();
                                txtDisplay.Text = currentEntry;
                            }
                            break;

                        case "%":
                            if (double.TryParse(currentEntry, out double percent))
                            {
                                percent = percent / 100;
                                currentEntry = percent.ToString();
                                txtDisplay.Text = currentEntry;
                            }
                            break;

                        case "+":
                        case "−":
                        case "×":
                        case "÷":
                            if (double.TryParse(currentEntry, out firstNumber))
                            {
                                operation = text;
                                isNewEntry = true;
                            }
                            break;

                        case "=":
                            if (double.TryParse(currentEntry, out double secondNumber))
                            {
                                double result = 0;

                                switch (operation)
                                {
                                    case "+": result = firstNumber + secondNumber; break;
                                    case "−": result = firstNumber - secondNumber; break;
                                    case "×": result = firstNumber * secondNumber; break;
                                    case "÷":
                                        if (secondNumber != 0)
                                            result = firstNumber / secondNumber;
                                        else
                                        {
                                            txtDisplay.Text = "Error";
                                            return;
                                        }
                                        break;
                                }

                                txtDisplay.Text = result.ToString();
                                currentEntry = result.ToString();
                                isNewEntry = true;
                            }
                            break;
                    }
                }
            }
        }
    }
}
