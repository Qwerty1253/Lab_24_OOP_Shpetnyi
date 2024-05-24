using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_24
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource[] cancellationTokenSources = new CancellationTokenSource[3];
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            buttonStartMMB.Click += (sender, e) => StartCryptoProcess(0, MMBAlgorithm, "MMB");
            buttonStartAR.Click += (sender, e) => StartCryptoProcess(1, ARHashFunction, "AR Hash");
            buttonStartPles.Click += (sender, e) => StartCryptoProcess(2, PlesseyGenerator, "Plessey");

            buttonStopMMB.Click += (sender, e) => StopCryptoProcess(0);
            buttonStopAR.Click += (sender, e) => StopCryptoProcess(1);
            buttonStopPles.Click += (sender, e) => StopCryptoProcess(2);

            buttonStartAll.Click += (sender, e) => {
                StartCryptoProcess(0, MMBAlgorithm, "MMB");
                StartCryptoProcess(1, ARHashFunction, "AR Hash");
                StartCryptoProcess(2, PlesseyGenerator, "Plessey");
            };

            buttonStopAll.Click += (sender, e) => {
                for (int i = 0; i < 3; i++) StopCryptoProcess(i);
            };
        }

        private void StartCryptoProcess(int index, Func<string, Task<string>> cryptoMethod, string algorithmName)
        {
            if (cancellationTokenSources[index] != null && !cancellationTokenSources[index].IsCancellationRequested)
                return;

            cancellationTokenSources[index] = new CancellationTokenSource();
            var token = cancellationTokenSources[index].Token;

            Control startButton = GetStartButton(index);
            Control stopButton = GetStopButton(index);
            RichTextBox outputBox = GetOutputBox(index);

            startButton.Enabled = false;
            stopButton.Enabled = true;

            Task.Run(async () => {
                while (!token.IsCancellationRequested)
                {
                    string input = GenerateRandomString(8);  // Генерируем случайную строку длиной 8 символов
                    string result = null;

                    try
                    {
                        result = await cryptoMethod(input);

                        if (token.IsCancellationRequested)
                        {
                            Invoke(new Action(() => {
                                AppendText(outputBox, Environment.NewLine + "Process was cancelled before updating result." + Environment.NewLine, Color.Red);
                            }));
                            break;
                        }

                        Invoke(new Action(() => {
                            AppendText(outputBox, algorithmName + ": ", Color.Blue);
                            AppendText(outputBox, input, Color.Green);
                            AppendText(outputBox, " -> ", Color.Black);
                            AppendText(outputBox, result + Environment.NewLine, Color.Red);
                            ScrollToBottom(outputBox);
                        }));
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() => {
                            AppendText(outputBox, $"Error: {ex.Message}" + Environment.NewLine, Color.Red);
                            ScrollToBottom(outputBox);
                        }));
                    }

                    await Task.Delay(1000); // Simulate some processing time to see the UI updates
                }

                Invoke(new Action(() => {
                    startButton.Enabled = true;
                    stopButton.Enabled = false;
                    UpdateAllButtonsState();
                }));
            }, token);

            UpdateAllButtonsState();
        }

        private void StopCryptoProcess(int index)
        {
            if (cancellationTokenSources[index] != null)
            {
                cancellationTokenSources[index].Cancel();
                cancellationTokenSources[index].Dispose();
                cancellationTokenSources[index] = null;
            }

            GetStopButton(index).Enabled = false;
            GetStartButton(index).Enabled = true;

            UpdateAllButtonsState();
        }

        private Task<string> MMBAlgorithm(string input)
        {
            // Simulate MMB algorithm (for demonstration purposes)
            using (var sha256 = SHA256.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var result = sha256.ComputeHash(inputBytes);
                return Task.FromResult(BitConverter.ToString(result).Replace("-", ""));
            }
        }

        private Task<string> ARHashFunction(string input)
        {
            // Simulate AR hash function (for demonstration purposes)
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var result = md5.ComputeHash(inputBytes);
                return Task.FromResult(BitConverter.ToString(result).Replace("-", ""));
            }
        }

        private Task<string> PlesseyGenerator(string input)
        {
            // Simulate Plessey generator (for demonstration purposes)
            using (var rng = new RNGCryptoServiceProvider())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var resultBytes = new byte[inputBytes.Length];
                rng.GetBytes(resultBytes);
                return Task.FromResult(BitConverter.ToString(resultBytes).Replace("-", ""));
            }
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(stringChars);
        }

        private void UpdateAllButtonsState()
        {
            bool anyRunning = false;
            bool allRunning = true;

            for (int i = 0; i < 3; i++)
            {
                if (cancellationTokenSources[i] != null && !cancellationTokenSources[i].IsCancellationRequested)
                {
                    anyRunning = true;
                }
                else
                {
                    allRunning = false;
                }
            }

            buttonStartAll.Enabled = !allRunning;
            buttonStopAll.Enabled = anyRunning;
        }

        // Helper methods to get the controls by index
        private System.Windows.Forms.Button GetStartButton(int index)
        {
            switch (index)
            {
                case 0: return buttonStartMMB;
                case 1: return buttonStartAR;
                case 2: return buttonStartPles;
                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        private System.Windows.Forms.Button GetStopButton(int index)
        {
            switch (index)
            {
                case 0: return buttonStopMMB;
                case 1: return buttonStopAR;
                case 2: return buttonStopPles;
                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        private System.Windows.Forms.RichTextBox GetOutputBox(int index)
        {
            switch (index)
            {
                case 0: return textBoxMMB;
                case 1: return textBoxAR;
                case 2: return textBoxPles;
                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        private void AppendText(System.Windows.Forms.RichTextBox textBox, string text, Color color)
        {
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;

            textBox.SelectionColor = color;
            textBox.AppendText(text);
            textBox.SelectionColor = textBox.ForeColor;
        }

        private void ScrollToBottom(System.Windows.Forms.RichTextBox textBox)
        {
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
        }
    }
}