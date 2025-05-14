using System;                           // Provides basic functionality like Console
using System.Collections.Generic;       // Enables use of List, Dictionary
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using NAudio.Wave; // Import NAudio for audio playback

namespace Chatbot
{
    internal class Program
    {
        // Stores user's name and interest
        static string userName;
        static string userInterest;

        // Dictionary mapping keywords to a list of cybersecurity tips
        static Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
        {
            { "password", new List<string>
                {
            "🔐 Use strong passwords like `B3@chSun!2024` instead of weak ones like `123456` or `password`.",
            "🚫 Never reuse passwords across sites. For example, don’t use your email password for your online banking.",
            "🎂 Avoid using names, birthdays, or pet names (e.g., `Tommy1995`). Use password managers to create & store secure ones!"
                }
            },
            { "phishing", new List<string>
                {
            "🎣 A phishing email might say: ‘Your bank account is locked, click here to unlock.’ Never click that link!",
            "📩 Avoid emails with urgent demands like ‘Act now!’ or ‘Confirm your login’ — especially from unknown addresses.",
            "🔍 If unsure, go directly to the website (e.g., type www.yourbank.com) instead of clicking links in suspicious emails."
                }
            },
            { "privacy", new List<string>
                {
            "🔒 Avoid granting apps access to your camera, contacts, or location unless necessary. For example, a calculator app doesn’t need GPS!",
            "👀 On platforms like Facebook or Instagram, set your posts to ‘Friends’ instead of ‘Public’. Only share what you’re comfortable with.",
            "🧹 Regularly clear your browser history and cookies to remove tracking data. Use ‘Incognito Mode’ when researching sensitive topics."
                }
            },
            { "browsing", new List<string>
                {
            "🌐 Use a VPN when on public Wi-Fi (like at a café) to encrypt your activity. Don’t log into your bank on unsecured networks.",
            "🚷 Avoid downloading files or clicking ads from untrusted sites. For example, ‘free movie download’ links often carry malware.",
            "🛡️ Keep Chrome, Firefox, or Edge updated. Enable browser security features like ‘Safe Browsing’ to detect harmful sites."
                }
            },
            { "scam", new List<string>
                {
            "⚠️ Common scam: ‘You’ve won a prize! Just send shipping fees.’ 🚩 Never send money to claim a prize you didn’t enter.",
            "🔎 Double-check charity websites during donation drives. Scammers clone real websites — look for misspelled URLs.",
            "📢 If you spot a scam, report it to platforms like Scamwatch, local cybercrime units, or the email provider."
                }
            }
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            Console.Clear(); // Clears the console window

            // Ask for user’s name
            Console.WriteLine("Hi there! I'm CyberLily 🤖 , your trusted cyber guardian! What is your name?");
            userName = Console.ReadLine(); // Store user name

            // Display ASCII art greeting with user's name
            Console.ForegroundColor = ConsoleColor.Magenta;
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
            Console.WriteLine(greetingMessage);
            Console.ResetColor();

            // Welcome banner
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n************************************************");
            Console.WriteLine("| WELCOME TO YOUR CYBERSECURITY ASSISTANT! |");
            Console.WriteLine("**************************************************");
            Console.ResetColor();

            // Ask the user what topic they're interested in
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nCyberLily: {userName}, is there a specific area of cybersecurity you're most curious about (e.g., password, phishing, privacy)?");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nYou: ");
            string interestInput = Console.ReadLine()?.ToLower(); // Capture user's interest
            Console.ResetColor();

            // Save interest if matched
            if (!string.IsNullOrEmpty(interestInput))
            {
                foreach (var keyword in keywordResponses.Keys)
                {
                    if (interestInput.Contains(keyword))
                    {
                        userInterest = keyword;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nCyberLily: Great! I'll remember that you're interested in {userInterest}. It's a crucial part of staying safe online.");
                        Console.ResetColor();
                        break;
                    }
                }
            }

            // Play audio greeting if file exists
            string audioFilePath = @"C:\\Users\\Lesedi Mathunya\\source\\repos\\Chatbot\\Chatbot\\bin\\Debug\\audio.wav.m4a";
            if (File.Exists(audioFilePath))
            {
                try
                {
                    using (var audioFileReader = new AudioFileReader(audioFilePath))
                    using (var waveOut = new WaveOutEvent())
                    {
                        waveOut.Init(audioFileReader);
                        waveOut.Play(); // Play the audio
                        Console.WriteLine("\n 🎧 Audio loaded and playing...");
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100); // Wait while playing
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
                Console.WriteLine("\nOops! Audio file not found. Please check the file path.");
                Console.WriteLine($"Expected location: {audioFilePath}");
            }

            // Begin chatbot loop
            bool firstTime = true; // Track if it's the first loop

            while (true)
            {
                if (firstTime)
                {
                // CyberLily checks in on user's well-being
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCyberLily: Before we jump in... how are you doing today?");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nYou: ");
                string moodInput = Console.ReadLine()?.ToLower();
                Console.ResetColor();

                // Respond with empathy or positivity
                if (!string.IsNullOrEmpty(moodInput))
                {
                    if (moodInput.Contains("good") || moodInput.Contains("great") || moodInput.Contains("fine") || moodInput.Contains("happy"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nCyberLily 🤖:  I'm feeling electric ⚡ and ready to help!  . 😊");
                        Console.WriteLine("\nCyberLily 🤖: That’s awesome to hear! 😊 A good mood makes everything better — even cybersecurity!");
                        Console.ResetColor();
                    }
                    else if (moodInput.Contains("bad") || moodInput.Contains("not great") || moodInput.Contains("tired") || moodInput.Contains("sad"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCyberLily 🤖: I’m sorry you’re feeling that way. Remember, I’m here to help and keep things simple 💡.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nCyberLily 🤖:  I'm feeling electric ⚡ and ready to help!  . 😊");
                        Console.WriteLine("\nCyberLily 🤖: Thanks for sharing! Let’s make today a little better together. 😊");
                        Console.ResetColor();
                    }
                }

                    firstTime = false; // Ensure mood is asked only once
                }

                // Ask for topic only
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCyberLily: What do you want to ask me about? I provide tips on password safety, phishing tip, scam, browsing, and privacy.");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nYou: ");
                string userInput = Console.ReadLine()?.ToLower();
                Console.ResetColor();

                // If input is empty or whitespace
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily: I didn't quite understand that. Could you rephrase?");
                    Console.ResetColor();
                    continue;
                }

                bool matched = false;

             
                // Human-like conversation: Responding to "how are you"
                if (userInput.Contains("how are you") || userInput.Contains("how are you doing") || userInput.Contains("how's it going"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily 🤖: I'm feeling electric ⚡ and ready to help! Thanks for asking, that was sweet 😊.");
                    Console.ResetColor();
                    matched = true;
                }

                // Special case for phishing tip request
                else if (userInput.Contains("phishing tip"))
                {
                    List<string> phishingTips = new List<string>
        {
            "• Be cautious of emails asking for personal information.",
            "• Don't click on links or download attachments from unknown senders.",
            "• Look out for urgent language in emails.",
            "• Check URLs carefully; phishing sites often mimic real ones.",
            "• Use two-factor authentication to protect your accounts."
        };
                    Random rand = new Random();
                    string tip = phishingTips[rand.Next(phishingTips.Count)];

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nCyberLily: {tip}");
                    Console.ResetColor();
                    continue;
                }

                // Check input for known keywords
                foreach (var keyword in keywordResponses.Keys)
                {
                    if (userInput.Contains(keyword))
                    {
                        if (string.IsNullOrEmpty(userInterest))
                        {
                            userInterest = keyword;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nCyberLily: Great! I'll remember that you're interested in {keyword}.");
                            Console.ResetColor();
                        }

                        Random rnd = new Random();
                        string randomTip = keywordResponses[keyword][rnd.Next(keywordResponses[keyword].Count)];

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nCyberLily: {randomTip}");
                        Console.ResetColor();
                        matched = true;
                        break;
                    }
                }

                // Sentiment detection for emotional support
                if (!matched)
                {
                    if (userInput.Contains("worried") || userInput.Contains("scared") || userInput.Contains("concerned"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCyberLily:It's okay to feel that way. Let's beat the cyber-baddies together! ");
                        Console.ResetColor();
                        matched = true;
                    }
                    else if (userInput.Contains("frustrated") || userInput.Contains("confused"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCyberLily: I get it — cybersecurity can be overwhelming. Let's take it one step at a time.");
                        Console.ResetColor();
                        matched = true;
                    }
                    else if (userInput.Contains("curious") || userInput.Contains("interested"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCyberLily:  Curiosity is the first step to cybersecurity greatness! ");
                        Console.ResetColor();
                        matched = true;
                    }
                }

                // Fallback if no match or sentiment found
                if (!matched)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily:Hmm 🤔... I'm not sure I understand. Can you try rephrasing?");
                    Console.ResetColor();
                }

                // Reminder based on saved user interest
                if (!string.IsNullOrEmpty(userInterest))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nCyberLily: As someone interested in {userInterest}, here's a reminder to regularly review related safety practices.");
                    Console.ResetColor();
                }

                // Ask user if they want to continue chatting
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCyberLily:  Want to keep chatting? (yes/no)");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nYou: ");
                    string continueInput = Console.ReadLine()?.ToLower();
                    Console.ResetColor();

                    if (continueInput == "yes")
                    {
                        break; // Loop continues
                    }
                    else if (continueInput == "no")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCyberLily 🤖: It was awesome chatting with you, {userName}! Stay sharp and stay safe. 🧠🔐");
                        Console.WriteLine("Remember: A day without cybersecurity is like a day without sunshine. ☀️");
                        Console.ResetColor();
                        return;// Exit program
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
