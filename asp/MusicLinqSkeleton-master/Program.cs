using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            IEnumerable<Artist> justMtVernon = Artists.Where(resulta => resulta.Hometown == "Mount Vernon");
            foreach (var a in justMtVernon)
            {
                Console.WriteLine(a.Age + " and " + a.ArtistName);
            }
            System.Console.WriteLine("\n++++++++++++++\n");

            //Who is the youngest artist in our collection of artists?
            IEnumerable<Artist> youngest = Artists.OrderByDescending(resultb => resultb.Age);
            Artist myYoungest = youngest.Last();
            System.Console.WriteLine(myYoungest.ArtistName + " and " + myYoungest.Age);
            System.Console.WriteLine("\n++++++++++++++\n");

            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> justWilliam = Artists.Where(resultc => resultc.RealName.Contains("William"));
            foreach (var a in justWilliam)
            {
                Console.WriteLine(a.RealName);
            }
            System.Console.WriteLine("\n++++++++++++++\n");

            //Display all groups with names less than 8 characters in length.
            IEnumerable<Group> eightChars = Groups.Where(resultf => resultf.GroupName.Length < 8);
            foreach(var b in eightChars)
            {
                System.Console.WriteLine(b.GroupName);
            }
            System.Console.WriteLine("\n++++++++++++++\n");

            //Display the 3 oldest artist from Atlanta
            IEnumerable<Artist> oldAtlanta = Artists.Where(resultd => resultd.Hometown == "Atlanta");
            IEnumerable<Artist> threeOldest = oldAtlanta.OrderByDescending(resulte => resulte.Age);
            int i = 0;
            foreach (var a in threeOldest)
            {
                if (i > 2)
                {
                    break;
                }
                System.Console.WriteLine(a.ArtistName + " and " + a.Age + " and " + a.Hometown);
                i++;
            }
            System.Console.WriteLine("\n++++++++++++++\n");

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            int myGroupId = 0;
            IEnumerable<Group> wtc = Groups.Where(resultf => resultf.GroupName == "Wu-Tang Clan");
            foreach(var w in wtc)
            {
                myGroupId = w.Id;
            }
            IEnumerable<Artist> wtcOnly = Artists.Where(resultg => resultg.GroupId == myGroupId);
            foreach(var a in wtcOnly)
            {
                System.Console.WriteLine(a.ArtistName);
            }
            System.Console.WriteLine("\n++++++++++++++\n");
            
            // Console.WriteLine(Groups.Count);
        }
    }
}
