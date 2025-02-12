
using System.Windows;
namespace VigenereCipher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly char[] asciiCharacters = new char[95];

        public MainWindow()
        {
            InitializeComponent();
            InitializeAsciiArray();
        }

        private void InitializeAsciiArray()
        {
            for (int i = 0; i < 95; i++)
            {
                asciiCharacters[i] = (char)(i + 32);
            }
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            string word = WordTextBox.Text;
            string key = KeyTextBox.Text;

            if (key.Length > word.Length)
            {
                MessageBox.Show("Key cannot be longer than the word.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ResultTextBox.Text = EncryptVigenere(word, key);
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            string encryptedText = WordTextBox.Text;
            string key = KeyTextBox.Text;

            if (key.Length > encryptedText.Length)
            {
                MessageBox.Show("Key cannot be longer than the word.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ResultTextBox.Text = DecryptVigenere(encryptedText, key);
        }

        private string EncryptVigenere(string text, string key)
        {
            char[] result = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                int keyIndex = i % key.Length;
                int textCharIndex = Array.IndexOf(asciiCharacters, text[i]);
                int keyCharIndex = Array.IndexOf(asciiCharacters, key[keyIndex]);

                if (textCharIndex == -1 || keyCharIndex == -1)
                {
                    result[i] = text[i];
                }
                else
                {
                    result[i] = asciiCharacters[(textCharIndex + keyCharIndex) % 95];
                }
            }
            return new string(result);
        }

        private string DecryptVigenere(string text, string key)
        {
            char[] result = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                int keyIndex = i % key.Length;
                int textCharIndex = Array.IndexOf(asciiCharacters, text[i]);
                int keyCharIndex = Array.IndexOf(asciiCharacters, key[keyIndex]);

                if (textCharIndex == -1 || keyCharIndex == -1)
                {
                    result[i] = text[i];
                }
                else
                {
                    result[i] = asciiCharacters[(textCharIndex - keyCharIndex + 95) % 95];
                }
            }
            return new string(result);
        }

    }
}
