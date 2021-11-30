using System;
using System.Collections.Generic;
using System.Text;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.Xna.Framework;

namespace My_Life
{
    [Serializable]
    public class SaveGame
    {
        public static void SaveSettingsInIsoStorage(int i)
        {
            IsolatedStorageFile applicationStorageFileForUser = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream applicationStorageStreamForUser;
            AppSettings settings;

            string money, banque, faim, sante, criminalite, tpsJeu;

                    if (!applicationStorageFileForUser.DirectoryExists("MyLife")) { applicationStorageFileForUser.CreateDirectory("MyLife"); }
                    applicationStorageStreamForUser = new IsolatedStorageFileStream("MyLife/savegame" + i + ".json", System.IO.FileMode.Create, applicationStorageFileForUser);
                    settings = new AppSettings();
                    {
                        settings.Money = Game1.Monnaie;
                        settings.Banque = Game1.Banque;
                        settings.Faim = Game1.faim;
                        settings.Sante = Game1.sante;
                        settings.Criminalite = Game1.criminalite;
                    }
                    money = JsonConvert.SerializeObject(settings.Money);
                    banque = JsonConvert.SerializeObject(settings.Banque);
                    faim = JsonConvert.SerializeObject(settings.Faim);
                    sante = JsonConvert.SerializeObject(settings.Sante);
                    criminalite = JsonConvert.SerializeObject(settings.Criminalite);
                    tpsJeu = JsonConvert.SerializeObject(settings.tpsJeu);

                    using (StreamWriter sw = new StreamWriter(applicationStorageStreamForUser))
                    {
                        sw.WriteLine("Temps de Jeu = " + tpsJeu);
                        sw.WriteLine("Monnaie = " + money);
                        sw.WriteLine("Banque = " + banque);
                        sw.WriteLine("Faim = " + faim);
                        sw.WriteLine("Sante = " + sante);
                        sw.WriteLine("Criminalite = " + criminalite);
                    }

        }
        public static void ReadSettingsFromIsoStorage(int loadSaveGame)
        {
            IsolatedStorageFile applicationStorageFileForUser = IsolatedStorageFile.GetUserStoreForAssembly();
                    if (applicationStorageFileForUser.FileExists("MyLife/savegame" + loadSaveGame + ".json"))
                    {

                        IsolatedStorageFileStream applicationStorageStreamForUser = new IsolatedStorageFileStream("MyLife/savegame" + loadSaveGame + ".json", FileMode.Open, applicationStorageFileForUser);
                        using (StreamReader sr = new StreamReader(applicationStorageStreamForUser))
                        {
                            string monnaie = sr.ReadLine();
                            string banque = sr.ReadLine();
                            string faim = sr.ReadLine();
                            string sante = sr.ReadLine();
                            string criminalite = sr.ReadLine();
                            string tpsJeu = sr.ReadLine();

                            try
                            {
                                Game1.Monnaie = Int32.Parse(monnaie.ToCharArray(9, monnaie.Length - 9));
                                Game1.Banque = Int32.Parse(banque.ToCharArray(9, banque.Length - 9));
                                Game1.faim = Int32.Parse(faim.ToCharArray(6, faim.Length - 6));
                                Game1.sante = Int32.Parse(sante.ToCharArray(7, sante.Length - 7));
                                Game1.criminalite = Int32.Parse(criminalite.ToCharArray(13, criminalite.Length - 13));
                            
                            }
                            catch
                            {
                                Game1.scene = 2;
                            }
                        }
                    }
            
        }
    }

    public class AppSettings
    {
        public int tpsJeu { get; set; }
        public int Money { get; set; }
        public int Banque { get; set; }
        public int Faim { get; set; }
        public int Sante { get; set; }
        public int Criminalite { get; set; }
    }
}
