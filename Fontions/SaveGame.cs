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
        public static void SaveSettingsInIsoStorage(int i, string nameSave)
        {
            IsolatedStorageFile applicationStorageFileForUser = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream applicationStorageStreamForUser;
            AppSettings settings;

            i--;

            string money, banque, faim, sante, criminalite, tpsJeu;

            applicationStorageStreamForUser = new IsolatedStorageFileStream("MyLife/savegame" + i + ".json", System.IO.FileMode.Create, applicationStorageFileForUser);
            settings = new AppSettings();
            {
                settings.NameSave = nameSave;
                settings.TPSJeu = Game1.TPS;
                settings.Money = Game1.Monnaie;
                settings.Banque = Game1.Banque;
                settings.Faim = Game1.faim;
                settings.Sante = Game1.sante;
                settings.Criminalite = Game1.criminalite;
            }

            nameSave = JsonConvert.SerializeObject(settings.NameSave);
            money = JsonConvert.SerializeObject(settings.Money);
            banque = JsonConvert.SerializeObject(settings.Banque);
            faim = JsonConvert.SerializeObject(settings.Faim);
            sante = JsonConvert.SerializeObject(settings.Sante);
            criminalite = JsonConvert.SerializeObject(settings.Criminalite);
            tpsJeu = JsonConvert.SerializeObject(settings.TPSJeu);

            using (StreamWriter sw = new StreamWriter(applicationStorageStreamForUser))
            {
                sw.WriteLine("Nom = " + nameSave);
                sw.WriteLine("Temps de Jeu = " + tpsJeu);
                sw.WriteLine("Monnaie = " + money);
                sw.WriteLine("Banque = " + banque);
                sw.WriteLine("Faim = " + faim);
                sw.WriteLine("Sante = " + sante);
                sw.WriteLine("Criminalite = " + criminalite);
            }

        }
        public static bool ReadSettingsFromIsoStorage(int loadSaveGame)
        {
            IsolatedStorageFile applicationStorageFileForUser = IsolatedStorageFile.GetUserStoreForAssembly();

            bool save = false;

            save = FileExist(loadSaveGame);
            
            if(!save) return false;
            else if (save)
            {
                IsolatedStorageFileStream applicationStorageStreamForUser = new IsolatedStorageFileStream("MyLife/savegame" + loadSaveGame + ".json", FileMode.Open, applicationStorageFileForUser);
                using (StreamReader sr = new StreamReader(applicationStorageStreamForUser))
                {
                    string nameSave = sr.ReadLine();
                    string tpsJeu = sr.ReadLine();
                    string monnaie = sr.ReadLine();
                    string banque = sr.ReadLine();
                    string faim = sr.ReadLine();
                    string sante = sr.ReadLine();
                    string criminalite = sr.ReadLine();

                    try
                    {
                        Game1.TPS = Int32.Parse(tpsJeu.ToCharArray(15, tpsJeu.Length - 15));
                        Game1.Monnaie = Int32.Parse(monnaie.ToCharArray(9, monnaie.Length - 9));
                        Game1.Banque = Int32.Parse(banque.ToCharArray(9, banque.Length - 9));
                        Game1.faim = Int32.Parse(faim.ToCharArray(6, faim.Length - 6));
                        Game1.sante = Int32.Parse(sante.ToCharArray(7, sante.Length - 7));
                        Game1.criminalite = Int32.Parse(criminalite.ToCharArray(13, criminalite.Length - 13));

                    }
                    catch
                    {
                        Game1.scene = 0;
                    }
                    return true;
                }
            }
            return false;
        }

        public static bool FileExist(int i)
        {
            IsolatedStorageFile applicationStorageFileForUser = IsolatedStorageFile.GetUserStoreForAssembly();
            if (applicationStorageFileForUser.FileExists("MyLife/savegame"+i+".json")) { return true; }
            return false;
        }

        public static string[] ReadSaveName()
        {
            string[] nameSave = new string[3];
            string[] tps = new string[3];

            IsolatedStorageFile applicationStorageFileForUser = IsolatedStorageFile.GetUserStoreForAssembly();

            for(int i = 0; i<nameSave.Length; i++)
            {
                if (FileExist(i))
                {
                    IsolatedStorageFileStream applicationStorageStreamForUser = new IsolatedStorageFileStream("MyLife/savegame" + i + ".json", FileMode.Open, applicationStorageFileForUser);
                    using (StreamReader sr = new StreamReader(applicationStorageStreamForUser))
                    {
                        nameSave[i] = sr.ReadLine();
                        tps[i] = sr.ReadLine();
                        if (nameSave[i] != "Nom = \"\"")
                            nameSave[i] = nameSave[i].Substring(6, nameSave[i].Length - 6);
                        else
                            nameSave[i] = "Sauvegarde";
                        tps[i] = tps[i].Substring(14, tps[i].Length - 14);

                        try
                        {
                            Game1.TPSinfo[i] = Int32.Parse(tps[i]);
                        }
                        catch { Game1.scene = 0; }

                    }
                }
                else { nameSave[i] = "Vide";
                    Game1.TPSInfoString[i] = "0";
                }

            }
            return nameSave;
        }
    }

    public class AppSettings
    {
        public string NameSave { get; set; }
        public int TPSJeu { get; set; }
        public int Money { get; set; }
        public int Banque { get; set; }
        public int Faim { get; set; }
        public int Sante { get; set; }
        public int Criminalite { get; set; }
    }
}
