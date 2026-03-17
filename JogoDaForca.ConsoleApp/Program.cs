using System.Security.Cryptography;

namespace JogoDaForca.ConsoleApp;

class Program
{
  static void Main(string[] args)
  {

    while (true)
    {
      ShowHeader();

      string randomWord = RandomWordGenerator();

      char[] correctWords = UpdateCorrectWords(randomWord);

      RunGame(randomWord, correctWords);

      if (!ShouldContinue())
        break;
    }

  }
  static void ShowHeader()
  {
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Jogo da Forca");
    Console.WriteLine("---------------------------------");
  }
  static string RandomWordGenerator()
  {
    string[] words = [
           "ABACATE",
            "ABACAXI",
            "ACEROLA",
            "AÇAÍ",
            "ARAÇÁ",
            "ABACATE",
            "BACABA",
            "BACURI",
            "BANANA",
            "CAJÁ",
            "CAJU",
            "CARAMBOLA",
            "CUPUAÇU",
            "GRAVIOLA",
            "GOIABA",
            "JABUTICABA",
            "JENIPAPO",
            "MAÇÃ",
            "MANGABA",
            "MANGA",
            "MARACUJÁ",
            "MURICI",
            "PEQUI",
            "PITANGA",
            "PITAYA",
            "SAPOTI",
            "TANGERINA",
            "UMBU",
            "UVA",
            "UVAIA"
       ];

    int randomIndex = RandomNumberGenerator.GetInt32(words.Length);

    string randomWord = words[randomIndex];

    return randomWord;
  }
  static char[] UpdateCorrectWords(string randomWord)
  {
    char[] correctWords = new char[randomWord.Length];

    for (int character = 0; character < correctWords.Length; character++)
    {
      correctWords[character] = '_';
    }

    return correctWords;
  }
  static void RunGame(string randomWord, char[] correctWords)
  {
    bool playerWin = false;
    bool playerLost = false;
    int errorCount = 0;

    while (!playerWin && !playerLost)
    {

      DrawHangman(errorCount);

      Console.WriteLine($"Palavras acertadas: {(string.Join("", correctWords))}");
      Console.WriteLine($"Erros cometidos: {errorCount}");

      Console.Write("Digite uma letra: ");
      string? strLetter = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(strLetter))
      {
        Console.WriteLine("Digite um caractere válido.");
        Console.ReadLine();
        continue;
      }

      char guessedLetter = char.ToUpper(Convert.ToChar(strLetter));
      bool isCorrectGuess = false;

      for (int counter = 0; counter < randomWord.Length; counter++)
      {
        char currentLetter = randomWord[counter];

        if (guessedLetter == currentLetter)
        {
          correctWords[counter] = guessedLetter;
          isCorrectGuess = true;
        }
      }

      if (!isCorrectGuess)
        errorCount++;

      playerWin = randomWord == string.Join("", correctWords);
      playerLost = errorCount > 5;

      if (playerWin)
      {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Você acertou! A palavra secreta era {randomWord}.");
        Console.WriteLine("---------------------------------");
      }
      else if (playerLost)
      {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Que azar! :( Tente novamente.");
        Console.WriteLine("---------------------------------");
      }

      Console.ReadLine();
    }
  }
  static void DrawHangman(int errorCount)
  {
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Jogo da Forca");
    Console.WriteLine("---------------------------------");

    if (errorCount == 0)
    {
      Console.WriteLine(@" ___________        ");
      Console.WriteLine(@" |/        |        ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@"_|____              ");
    }

    else if (errorCount == 1)
    {
      Console.WriteLine(@" ___________        ");
      Console.WriteLine(@" |/        |        ");
      Console.WriteLine(@" |         o        ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@"_|____              ");
    }

    else if (errorCount == 2)
    {
      Console.WriteLine(@" ___________        ");
      Console.WriteLine(@" |/        |        ");
      Console.WriteLine(@" |         o        ");
      Console.WriteLine(@" |         |        ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@"_|____              ");
    }

    else if (errorCount == 3)
    {
      Console.WriteLine(@" ___________        ");
      Console.WriteLine(@" |/        |        ");
      Console.WriteLine(@" |         o        ");
      Console.WriteLine(@" |        /|        ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@"_|____              ");
    }

    else if (errorCount == 4)
    {
      Console.WriteLine(@" ___________        ");
      Console.WriteLine(@" |/        |        ");
      Console.WriteLine(@" |         o        ");
      Console.WriteLine(@" |        /|\       ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@"_|____              ");
    }

    else if (errorCount == 5)
    {
      Console.WriteLine(@" ___________        ");
      Console.WriteLine(@" |/        |        ");
      Console.WriteLine(@" |         o        ");
      Console.WriteLine(@" |        /|\       ");
      Console.WriteLine(@" |        / \       ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@" |                  ");
      Console.WriteLine(@"_|____              ");
    }

    Console.WriteLine("---------------------------------");
  }
  static bool ShouldContinue()
  {
    Console.Write("Deseja continuar o jogo? (s/N): ");
    string? opcaoContinuar = Console.ReadLine()?.ToUpper();

    if (opcaoContinuar != "S")
      return false;

    return true;
  }
}