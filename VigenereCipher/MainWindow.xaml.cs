
using System.Windows;
namespace VigenereCipher
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
                int encryptedValue = ((text[i] - 32) + (key[keyIndex] - 32)) % 95 + 32;
                result[i] = (char)encryptedValue;
            }
            return new string(result);
        }



        private string DecryptVigenere(string text, string key)
        {
            char[] result = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                int keyIndex = i % key.Length;
                int decryptedValue = ((text[i] - 32) - (key[keyIndex] - 32) + 95) % 95 + 32; //strange byte fix to avoid 
                result[i] = (char)decryptedValue;                                       //bugs when ascii encrypt/decrypt
            }
            return new string(result);
        }

    }
}
