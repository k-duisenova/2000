using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    enum FSIMode
    {
        DIR, FILE
    }
    class Layer
    {
        int selectedIndex;
        /// <summary>
        /// access to folders
        /// </summary>
        public DirectoryInfo[] Directories
        {
            get;
            set;
        }
        /// <summary>
        /// access to all other files
        /// </summary>
        public FileInfo[] Files
        {
            get;
            set;
        }
        public int SelectedIndex
        {
            get
            {
                return selectedIndex; // returns the index of the selected item
            }
            set
            {
                if (value < 0) selectedIndex = Directories.Length + Files.Length - 1; // going down through the list
                else if (value > Directories.Length + Files.Length - 1) selectedIndex = 0; // returning back to the start
                else selectedIndex = value;
            }
        }
        void SelectedColor(int i)
        {
            if (i == SelectedIndex)
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            else
                Console.BackgroundColor = ConsoleColor.Black;
        }
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < Directories.Length; i++)
            {
                SelectedColor(i);
                Console.WriteLine((i + 1) + ". " + Directories[i].Name); // drawing the folders with their order
            }
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < Files.Length; i++)
            {
                SelectedColor(i + Directories.Length);
                Console.WriteLine((i + Directories.Length + 1) + ". " + Files[i].Name); // drawing the files with another color
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\c++");
            Layer l = new Layer
            {
                Directories = directoryInfo.GetDirectories(),
                Files = directoryInfo.GetFiles(),
                SelectedIndex = 0
            };
            Stack<Layer> history = new Stack<Layer>();
            history.Push(l);
           
            FSIMode mode = FSIMode.DIR;
            while (true)
            {
                if (mode == FSIMode.DIR)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo ConsoleKey = Console.ReadKey();
                if (ConsoleKey.Key == System.ConsoleKey.UpArrow)
                    history.Peek().SelectedIndex--;

                else if (ConsoleKey.Key == System.ConsoleKey.DownArrow)
                    history.Peek().SelectedIndex++;

                else if (ConsoleKey.Key == System.ConsoleKey.Enter)
                {
                    int x = history.Peek().SelectedIndex;
                    if (x < history.Peek().Directories.Length) // opening the folders
                    {
                        DirectoryInfo d = history.Peek().Directories[x];
                        Layer ly = new Layer
                        {
                            Directories = d.GetDirectories(),
                            Files = d.GetFiles(),
                            SelectedIndex = 0
                        };
                        history.Push(ly);
                    }
                    else
                    {
                        mode = FSIMode.FILE;
                        StreamReader sr = new StreamReader(history.Peek().Files[x - history.Peek().Directories.Length].FullName);
                        string s = sr.ReadToEnd();
                        sr.Close();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine(s);
                    }
                }

                else if (ConsoleKey.Key == System.ConsoleKey.Backspace)
                {
                    if (mode == FSIMode.DIR)
                    {
                        if (history.Count > 1) 
                            history.Pop();
                    }
                    else
                        mode = FSIMode.DIR; // if it is the first layer, then everything stays the same
                }


                else if (ConsoleKey.Key == System.ConsoleKey.Delete)
                {
                    int delete = history.Peek().SelectedIndex;
                  
                    if (delete < history.Peek().Directories.Length)
                    {
                        history.Peek().Directories[delete].Delete(true);
                    }
                    else
                    {
                        history.Peek().Files[delete - history.Peek().Directories.Length].Delete();
                    }
                    history.Pop();
                    
                    // if all layers are closed
                    if (history.Count() == 0)
                    {
                        Layer lay = new Layer
                        {
                            Directories = directoryInfo.GetDirectories(),
                            Files = directoryInfo.GetFiles(),
                            SelectedIndex = delete--
                        };
                        history.Push(lay);
                    }
                    // if you are in subdirectory
                    else 
                    {
                        int i = history.Peek().SelectedIndex;
                        DirectoryInfo dd = history.Peek().Directories[i];
                        Layer ly = new Layer
                        {
                            Directories = dd.GetDirectories(),
                            Files = dd.GetFiles(),
                            SelectedIndex = delete--
                        };
                        history.Push(ly);
                    }
                }


                else if (ConsoleKey.Key == System.ConsoleKey.R)
                {
                    Console.Clear();
                    int rename = history.Peek().SelectedIndex;
                    int i = rename;
                    string name, fullname;
                    int selectedMode;

                    if (rename < history.Peek().Directories.Length)
                    {
                        name = history.Peek().Directories[rename].Name;
                        fullname = history.Peek().Directories[rename].FullName;
                        selectedMode = 1;
                    }
                    else
                    {
                        name = history.Peek().Files[rename - history.Peek().Directories.Length].Name;
                        fullname = history.Peek().Files[rename - history.Peek().Directories.Length].FullName;
                        selectedMode = 2;
                    }

                    string path = fullname.Remove(fullname.Length - name.Length);
                    Console.WriteLine("Please enter the new name");
                    string newname = Console.ReadLine();

                    if (selectedMode == 1)
                    {
                        new DirectoryInfo(history.Peek().Directories[rename].FullName).MoveTo(path + newname);
                    }
                    else
                    {
                        new FileInfo(history.Peek().Files[rename - history.Peek().Directories.Length].FullName).MoveTo(path + newname);
                    }
                    history.Pop();


                    if (history.Count == 0)
                    {
                        Layer lay = new Layer
                        {
                            Directories = directoryInfo.GetDirectories(),
                            Files = directoryInfo.GetFiles(),
                            SelectedIndex = i
                        };
                        history.Push(lay);
                    }
                    else
                    {
                        rename = history.Peek().SelectedIndex;
                        DirectoryInfo dir = history.Peek().Directories[rename];
                        Layer ly = new Layer
                        {
                            Directories = dir.GetDirectories(),
                            Files = dir.GetFiles(),
                            SelectedIndex = i
                        };
                        history.Push(ly);
                    }
                }
            }

        }
    }
}
