using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using NAudio.Wave;// Add NAudio namespace

namespace Chatbot
{
    internal class Program
    {
        private static string GetUserName()
        {
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {


            Console.Clear();

            // Ask for the user's name
            Console.WriteLine("Hi there! I'm CyberLily, your trusted cyber guardian! What is your name?");
            string userName = Console.ReadLine();

            // Change the text color to red
            Console.ForegroundColor = ConsoleColor.Red;

            // Display the personalized greeting and ASCII art
            string greetingMessage = $@"
       Welcome to CyberLily, {userName}! 

   ██████╗██╗   ██╗██████╗ ███████╗██████╗ 
  ██╔════╝██║   ██║██╔══██╗██╔════╝██╔══██╗
  ██║     ██║   ██║██████╔╝█████╗  ██████╔╝
  ██║     ██║   ██║██╔══██╗██╔══╝  ██╔═══╝ 
  ╚██████╗╚██████╔╝██║  ██║███████╗██║     
   ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝     

I'm here to make your digital experience safe and secure!  
How can I assist you today, {userName}? 
";

            // Display the greeting message
            Console.WriteLine(greetingMessage);

            // Reset color back to normal
            Console.ResetColor();

            // Display Welcome Message
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n************************************************");
            Console.WriteLine("| WELCOME TO YOUR CYBERSECURITY ASSISTANT! |");
            Console.WriteLine("**************************************************");
            Console.ResetColor();

            // Define the correct path to the audio file
            string audioFilePath = @"C:\Users\Lesedi Mathunya\source\repos\Chatbot\Chatbot\bin\Debug\audio.wav.m4a";  // Adjust path

            // Check if the audio file exists before trying to play it
            if (File.Exists(audioFilePath))
            {
                try
                {
                    // Create a new AudioFileReader instance to read the .m4a file
                    using (var audioFileReader = new AudioFileReader(audioFilePath))
                    {
                        // Create a WaveOutEvent to play the audio
                        using (var waveOut = new WaveOutEvent())
                        {
                            waveOut.Init(audioFileReader);
                            waveOut.Play();
                            Console.WriteLine("\nAudio loaded and playing...");

                            // Wait until the audio finishes playing
                            while (waveOut.PlaybackState == PlaybackState.Playing)
                            {
                                System.Threading.Thread.Sleep(100); // Add a small delay to avoid max CPU usage
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error playing audio: {ex.Message}");
                }
            }
            else
            {
                // Display an error message if the file is not found
                Console.WriteLine("\nOops! Audio file not found. Please check the file path.");
                Console.WriteLine($"Expected location: {audioFilePath}");

            }


            // Introduction message with red color
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hi there! I'm CyberLily, your trusted cyber guardian!");
            Console.ResetColor();

            // Personalized greeting in red
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Welcome to CyberLily, {userName}!");
            Console.ResetColor();


            // Main loop for user interaction
            while (true)
            {
                // Ask the first question
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCyberLily: What do you want to ask me about? I provide tips on password safety, phishing protection, and safe browsing.");
                Console.ResetColor();

                // Get user input with green text
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nYou: ");
                string userInput = Console.ReadLine()?.ToLower();
                Console.ResetColor();

                // Handle empty or invalid input
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily: I didn't quite understand that. Could you rephrase?");
                    Console.ResetColor();
                    continue;
                }

                // Respond to various questions
                if (userInput.Contains("how are you"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily: I'm doing great! I'm here to help you stay safe online.");
                }
                else if (userInput.Contains("what's your purpose") || userInput.Contains("what is your purpose"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily: My purpose is to keep you informed and protected from cybersecurity threats.");
                }
                else if (userInput.Contains("what can i ask you about"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily: You can ask me about password safety, phishing protection, and safe browsing.");
                }
                else if (userInput.Contains("password safety"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily: Use strong passwords with a mix of letters, numbers, and special characters.");
                }
                else if (userInput.Contains("phishing"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily: Phishing is when hackers trick you into giving personal info. Be cautious of suspicious emails.");
                }
                else if (userInput.Contains("safe browsing"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily: Always check for 'https' in URLs and avoid clicking on suspicious links.");
                }
                else if (userInput.Contains("exit") || userInput.Contains("quit"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily: It was nice chatting with you! Stay safe online. Goodbye!");
                    Console.ResetColor();
                    break; // Exit the program
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily: I'm sorry, I didn't quite understand that. Try asking about password safety, phishing, or safe browsing.");
                }

                // Reset text color
                Console.ResetColor();

                // Ask if the user wants to continue
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily: Do you want to continue? (yes/no)");
                    Console.ResetColor();

                    // Get user's response
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nYou: ");
                    string continueInput = Console.ReadLine()?.ToLower();
                    Console.ResetColor();

                    if (continueInput == "yes")
                    {
                        break; // Continue the outer loop
                    }
                    else if (continueInput == "no")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCyberLily: It was nice chatting with you! Stay safe online. Goodbye!");
                        Console.ResetColor();
                        return; // Exit the program
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCyberLily: Please respond with 'yes' or 'no'.");
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}

