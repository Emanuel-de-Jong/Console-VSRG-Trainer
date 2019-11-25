using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Media;
using System.IO;

namespace _10kTrainer2point0
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);
        static Random rnd = new Random();
        static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + rnd.Next(n - i);
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
        static void Main()
        {
            //assiging of the variables
            bool check = true;
            bool displayKeybinds = true;
            bool repeatOnce = true;
            string strTemp = String.Empty;
            string strTemp2 = String.Empty;
            string noteAmount = String.Empty;
            string soundEffect = String.Empty;
            string answer = String.Empty;
            string[] strArrTemp;
            List<string> strListTemp = new List<string>();
            double precentage = 0;
            int keyAmount = 0;
            int intNoteAmount = 0;
            int score = 0;
            int[] numbers;
            List<int> notePositions = new List<int>();
            List<ConsoleKeyInfo> keyBinds = new List<ConsoleKeyInfo>();
            List<ConsoleColor> noteColors = new List<ConsoleColor>();
            ConsoleColor backgroundColor = ConsoleColor.Black;
            Process p = Process.GetCurrentProcess();
            System.Media.SoundPlayer player = new SoundPlayer();

            //makes the console the size of the screen
            ShowWindow(p.MainWindowHandle, 3);
            Thread.Sleep(25);

            //writes "VSRG Finger Trainer" in biig letters
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, Console.WindowHeight / 2 - 14);
            Console.WriteLine(@" __      _______ _____   _____    ______ _                         _______        _                 ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, Console.WindowHeight / 2 - 13);
            Console.WriteLine(@" \ \    / / ____|  __ \ / ____|  |  ____(_)                       |__   __|      (_)                ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, Console.WindowHeight / 2 - 12);
            Console.WriteLine(@"  \ \  / / (___ | |__) | |  __   | |__   _ _ __   __ _  ___ _ __     | |_ __ __ _ _ _ __   ___ _ __ ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, Console.WindowHeight / 2 - 11);
            Console.WriteLine(@"   \ \/ / \___ \|  _  /| | |_ |  |  __| | | '_ \ / _` |/ _ \ '__|    | | '__/ _` | | '_ \ / _ \ '__|");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, Console.WindowHeight / 2 - 10);
            Console.WriteLine(@"    \  /  ____) | | \ \| |__| |  | |    | | | | | (_| |  __/ |       | | | | (_| | | | | |  __/ |   ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, Console.WindowHeight / 2 - 9);
            Console.WriteLine(@"     \/  |_____/|_|  \_\\_____|  |_|    |_|_| |_|\__, |\___|_|       |_|_|  \__,_|_|_| |_|\___|_|   ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, Console.WindowHeight / 2 - 8);
            Console.WriteLine(@"                                                  __/ |                                             ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, Console.WindowHeight / 2 - 7);
            Console.WriteLine(@"                                                 |___/                                              ");
            Console.SetCursorPosition(Console.WindowWidth - 16, Console.WindowHeight - 3);

            //displays the version
            Console.WriteLine("Version 0.0");

            //displays a fake loading screen
            for (int i = 1; i <= 50; i++)
            {
                precentage += 2;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.WindowHeight / 2 + 5);
                Console.Write(Convert.ToInt32(precentage) + "%");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 25 + i, Console.WindowHeight / 2 + 5);
                Console.Write(" ");
                Thread.Sleep(30);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            //if the settings files already exist, read them and assign the variables to them. Otherwise go trough the settings methodes
            //if (File.Exists(Environment.CurrentDirectory + "\\settings\\values.txt") && File.Exists(Environment.CurrentDirectory + "\\settings\\keyBinds.txt") && File.Exists(Environment.CurrentDirectory + "\\settings\\noteColors.txt"))
            //{
            //    //reads values.txt which has "keyAmount", "noteAmount" and "soundEffect" in it
            //    strListTemp = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\settings\\values.txt").ToList();
            //    keyAmount = Convert.ToInt16(strListTemp[0]);
            //    noteAmount = strListTemp[1];
            //    soundEffect = strListTemp[2];

            //    //reads keyBinds.txt, converts the lines to ConsoleKeyInfos and adds them to ConsoleKeyInfo List keyBinds
            //    strListTemp = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\settings\\keyBinds.txt").ToList();
            //    for (int i = 0; i < keyAmount; i++)
            //    {
            //        strTemp = strListTemp[i];
            //        strArrTemp = strTemp.Split(' ');
            //        strTemp = strArrTemp[0];
            //        strTemp2 = strArrTemp[1];
            //        keyBinds.Add(new ConsoleKeyInfo(Convert.ToChar(strTemp), (ConsoleKey)Enum.ToObject(typeof(ConsoleKey), Convert.ToInt16(strTemp2)), false, false, false));
            //    }

            //    //reads noteColors.txt converts the colors to ConsoleColors and adds them to ConsoleColor List noteColors
            //    strListTemp = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\settings\\noteColors.txt").ToList();
            //    for (int i = 0; i < strListTemp.Count; i++)
            //    {
            //        noteColors.Add((ConsoleColor)Enum.Parse(typeof(ConsoleColor), strListTemp[i]));
            //    }
            //}
            //else
            //{
                //goes trough most settings
                keyAmountMethode(check, strTemp, ref keyAmount);
                keyBindMethode(ref keyBinds, keyAmount, check, answer, repeatOnce);
                noteAmountMethode(check, ref noteAmount, keyAmount);
                soundEffectMethode(check, ref soundEffect, player, answer);
                noteColorMethode(keyAmount, strTemp, ref noteColors, backgroundColor);
                valuesToFile(keyAmount, noteAmount, soundEffect, strListTemp);
                keyBindsToFile(keyBinds, strListTemp);
                noteColorsToFile(noteColors, strListTemp);
            //}

            //makes a list with jumps of 5
            notePositions.Add(0);
            for (int i = 0; i < keyAmount; i++)
            {
                notePositions.Add(notePositions[i]+5);
            }

            //makes a list of numbers (0, 1, 2,...)
            numbers = Enumerable.Range(0, keyAmount).ToArray();

            if (soundEffect != "silent")
            {
                player = new System.Media.SoundPlayer(soundEffect);
            }
            //if noteAmount is not "random" then intNoteAmount will be assigned to it. 
            //I need this because when it is, I need a different variable to not overwrite the text "random"
            if (noteAmount != "random")
            {
                intNoteAmount = Convert.ToInt16(noteAmount);
            }
            //the main program, that loops everytime certain keys corresponding to the keybinds with the indexes of the scrambled list numbers are pressed
            while (true)
            {
                Console.Clear();
                if (noteAmount == "random")
                {
                    intNoteAmount = rnd.Next(1, keyAmount);
                }
                //displays the keybinds underneath the keys for reference
                if (displayKeybinds)
                {
                    for (int i = 0; i < keyAmount; i++)
                    {
                        Console.SetCursorPosition(notePositions[i] + 2, 27);
                        Console.Write(keyBinds[i].Key);
                    }
                }
                check = true;
                Console.SetCursorPosition(0, 0);
                //displays the keybinds to change settings
                Console.WriteLine("1 - Change the key amount\n" +
                    "2 - Change the key binds\n" +
                    "3 - Change the note amount\n" +
                    "4 - Change the sound effect\n" +
                    "5 - Change the note colors\n" +
                    "6 - Change the background color\n" +
                    "7 - Toggle the keybind display");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2 - 20);
                //displays the score(amount of times, notes have been pressed correctly)
                Console.WriteLine("Score: " + score++);
                //this schuffle makes so random notes\keybinds get chosen every loop
                Shuffle(numbers);
                //notes are basically spaces with a position and a bg color
                //here the amount given by the user (noteAmount) are created
                for (int i = 0; i < intNoteAmount; i++)
                {
                    Console.SetCursorPosition(notePositions[numbers[i]], 25);
                    Console.BackgroundColor = noteColors[numbers[i]];
                    Console.Write("     ");
                }
                Console.WriteLine();
                //checks if the right keybinds are pressed (key by key, because I couldn't find any better way)
                for (int i = 0; i < intNoteAmount; i++)
                {
                    Console.BackgroundColor = backgroundColor;
                    while (!(keyBinds[numbers[i]].Key == Console.ReadKey(true).Key))
                    {
                        //this is the only while loop in the main loop, so here I check if the keybinds to change settings are pressed
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            //different settings need a different amount of changes. If the user wan't to change the key amount, he will have to change a lot of other settings as well
                            keyAmountMethode(check, strTemp, ref keyAmount);
                            keyBindMethode(ref keyBinds, keyAmount, check, answer, repeatOnce);
                            noteColorMethode(keyAmount, strTemp, ref noteColors, backgroundColor);
                            numbers = Enumerable.Range(0, keyAmount).ToArray();
                            valuesToFile(keyAmount, noteAmount, soundEffect, strListTemp);
                            keyBindsToFile(keyBinds, strListTemp);
                            noteColorsToFile(noteColors, strListTemp);
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.D2)
                        {
                            keyBindMethode(ref keyBinds, keyAmount, check, answer, repeatOnce);
                            keyBindsToFile(keyBinds, strListTemp);
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.D3)
                        {
                            noteAmountMethode(check, ref noteAmount, keyAmount);
                            if (noteAmount != "random")
                            {
                                intNoteAmount = Convert.ToInt16(noteAmount);
                            }
                            valuesToFile(keyAmount, noteAmount, soundEffect, strListTemp);
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.D4)
                        {
                            soundEffectMethode(check, ref soundEffect, player, answer);
                            if (soundEffect != "silent")
                            {
                                player = new System.Media.SoundPlayer(soundEffect);
                            }
                            valuesToFile(keyAmount, noteAmount, soundEffect, strListTemp);
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.D5)
                        {
                            noteColorMethode(keyAmount, strTemp, ref noteColors, backgroundColor);
                            noteColorsToFile(noteColors, strListTemp);
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.D6)
                        {
                            bakcgroundColorMethode(check, ref backgroundColor, strTemp);
                            for (int I = 0; i < noteColors.Count; i++)
                            {
                                if (noteColors[i] == backgroundColor)
                                {
                                    check = false;
                                }
                            }
                            if (!check)
                            {
                                noteColorMethode(keyAmount, strTemp, ref noteColors, backgroundColor);
                            }
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.D7)
                        {
                            if (displayKeybinds)
                            {
                                displayKeybinds = false;
                            }
                            else
                            {
                                displayKeybinds = true;
                            }
                        }
                    }
                }
                //if the right keys are pressed and soundEffect is not "silent", a sound effect will play
                if (soundEffect != "silent")
                {
                    player.Play();
                }
            }
        }
        //the next methodes are the user assigned settings, most have if statements with bool checks that loop untill the input is valid
        static void keyAmountMethode(bool check, string strTemp, ref int keyAmount)
        {
            Console.Clear();
            while (check)
            {
                //assigns keyAmount
                Console.WriteLine("How many keys do you play with? \"1-20\"");
                strTemp = Console.ReadLine().ToLower();
                //if it is between 1 and 20
                if (strTemp != "" && strTemp.All(char.IsDigit) && Convert.ToInt32(strTemp) >= 1 && Convert.ToInt32(strTemp) <= 20)
                {
                    keyAmount = Convert.ToInt16(strTemp);
                    check = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The input was invalid!");
                }
            }
            Console.Clear();
        }
        static void keyBindMethode(ref List<ConsoleKeyInfo> keyBinds, int keyAmount, bool check, string answer, bool repeatOnce)
        {
            Console.Clear();
            bool repeatKeyBinder = true;
            while (repeatKeyBinder)
            {
                //adds keys to keyBinds untill it has the same amount as keyAmount because every keybind should represent a key
                Console.WriteLine("What are your preffered keybinds?");
                for (int i = 0; i < keyAmount; i++)
                {
                    Console.WriteLine("\nKey" + (i + 1) + ":");
                    keyBinds.Add(Console.ReadKey());
                    Console.SetCursorPosition(0, i * 2 + 2);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.Write(keyBinds[i].Key);
                }
                //asks if the keybinds are right while still displaying them and repeats the binding if they are not
                while (check)
                {
                    //repeat once is so "Are these keybinds correct?" and "The input was invalid!" aren't spammed
                    if (repeatOnce)
                    {
                        Console.WriteLine("\n\nAre these keybinds correct? \"yes\" or \"no\"");
                        Console.SetCursorPosition(0, keyAmount * 2 + 5);
                    }
                    answer = Console.ReadLine().ToLower();
                    Console.SetCursorPosition(0, keyAmount * 2 + 5);
                    Console.Write(new string(' ', Console.WindowWidth));
                    if (answer == "yes" || answer == "no")
                    {
                        check = false;
                    }
                    else
                    {
                        if (repeatOnce)
                        {
                            Console.SetCursorPosition(0, keyAmount * 2 + 4);
                            Console.WriteLine("The input was invalid!");
                            repeatOnce = false;
                        }
                    }
                }
                check = true;
                if (answer == "yes")
                {
                    repeatKeyBinder = false;
                }
                else
                {
                    //if the keybinding is repeated, keyBinds should be reset
                    keyBinds = new List<ConsoleKeyInfo>();
                }
                repeatOnce = true;
                Console.Clear();
            }
        }
        static void noteAmountMethode(bool check, ref string noteAmount, int keyAmount)
        {
            Console.Clear();
            while (check)
            {
                //assigns noteAmount (the amount of 'notes' displayed simultanieusly\the amount of keys to press)
                Console.WriteLine("How many notes should come on the screen simultaneously? \"equal or lower to your key amount\" or \"random\"");
                noteAmount = Console.ReadLine().ToLower();
                //if its "random" or between 1 and keyAmount
                if (noteAmount == "random" || noteAmount != "" && noteAmount.All(char.IsDigit) && Convert.ToInt32(noteAmount) >= 1 && Convert.ToInt32(noteAmount) <= keyAmount)
                {
                    check = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The input was invalid!");
                }
            }
            Console.Clear();
        }
        static void soundEffectMethode(bool check, ref string soundEffect, System.Media.SoundPlayer player, string answer)
        {
            Console.Clear();
            bool previeuw = true;
            while (check)
            {
                //assigns soundEffect
                Console.WriteLine("What sound effect would you like to hear? \"clap\", \"drop\", \"pop\", \"tik\" or \"silent\"");
                soundEffect = Console.ReadLine().ToLower();
                if (soundEffect == "clap" || soundEffect == "drop" || soundEffect == "pop" || soundEffect == "tik")
                {
                    soundEffect = Environment.CurrentDirectory + "\\sounds\\" + soundEffect + ".wav";
                    check = false;
                }
                else if (soundEffect == "silent")
                {
                    check = false;
                    previeuw = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The input was invalid!");
                }
            }
            Console.Clear();
            check = true;
            //asks if the user wants to hear it
            while (previeuw)
            {
                Console.WriteLine("Would you like a previeuw of the sound effect? \"yes\" or \"no\"");
                answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "no")
                {
                    previeuw = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The input was invalid!");
                }
            }
            Console.Clear();
            previeuw = true;
            //if so, asks the user if he wants to keep it(ends the methode) or not(repeats the methode)
            if (answer == "yes")
            {
                player = new System.Media.SoundPlayer(soundEffect);
                player.Play();
                while (check)
                {
                    Console.WriteLine("Would you like to keep this sound effect? \"yes\" or \"no\"");
                    answer = Console.ReadLine().ToLower();
                    if (answer == "yes" || answer == "no")
                    {
                        check = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The input was invalid!");
                    }
                }
                check = true;
                if (answer == "no")
                {
                    soundEffectMethode(check, ref soundEffect, player, answer);
                }
            }
            Console.Clear();
        }
        static void noteColorMethode(int keyAmount, string strTemp, ref List<ConsoleColor> noteColors, ConsoleColor backgroundColor)
        {
            Console.Clear();
            Console.WriteLine("What are your preffered note colors? for example \"Blue\" or \"DarkGray\"");
            //adds colors to noteColors
            for (int i = 0; i < keyAmount; i++)
            {
                Console.WriteLine("\nNote" + (i + 1) + ":");
                strTemp = Console.ReadLine();
                if (Enum.TryParse(strTemp, out ConsoleColor result) && strTemp != Convert.ToString(backgroundColor))
                {
                    noteColors.Add((ConsoleColor)Enum.Parse(typeof(ConsoleColor), strTemp));
                }
                else
                {
                    Console.Clear();
                    i--;
                    Console.WriteLine("What are your preffered note colors? for example \"Blue\" or \"DarkGray\"");
                    Console.WriteLine("The input was invalid!");
                }
            }
            Console.Clear();
        }
        static void bakcgroundColorMethode(bool check, ref ConsoleColor backgroundColor, string strTemp)
        {
            //changes the backgroundcolor
            Console.Clear();
            while (check)
            {
                Console.WriteLine("What color do you want the background to have? \"Blue\" or \"DarkGray\"");
                strTemp = Console.ReadLine().ToLower();
                if (Enum.TryParse(strTemp, out ConsoleColor result) && strTemp != "White" && strTemp != "Red")
                {
                    backgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), strTemp);
                    Console.BackgroundColor = backgroundColor;
                    check = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The input was invalid!");
                }
            }
            Console.Clear();
        }

        //these methodes save most of the settings to text files
        static void valuesToFile(int keyAmount, string noteAmount, string soundEffect, List<string> strListTemp)
        {
            strListTemp = new List<string>();
            strListTemp = new List<string> { Convert.ToString(keyAmount), noteAmount, soundEffect };
            System.IO.File.WriteAllLines(Environment.CurrentDirectory + "\\settings\\values.txt", strListTemp);
        }
        static void keyBindsToFile(List<ConsoleKeyInfo> keyBinds, List<string> strListTemp)
        {
            strListTemp = new List<string>();
            for (int i = 0; i < keyBinds.Count; i++)
            {
                //ConsoleKeyInfos need a .KeyChar, the value of a .Key and modifiers, but I want the modifiers to always be false, so I don't need to save them
                strListTemp.Add(Convert.ToString(keyBinds[i].KeyChar) + " " + Convert.ToString((int)keyBinds[i].Key));
            }
            System.IO.File.WriteAllLines(Environment.CurrentDirectory + "\\settings\\keyBinds.txt", strListTemp);
        }
        static void noteColorsToFile(List<ConsoleColor> noteColors, List<string> strListTemp)
        {
            strListTemp = new List<string>();
            for (int i = 0; i < noteColors.Count; i++)
            {
                strListTemp.Add(Convert.ToString(noteColors[i]));
            }
            System.IO.File.WriteAllLines(Environment.CurrentDirectory + "\\settings\\noteColors.txt", strListTemp);
        }
    }
}
