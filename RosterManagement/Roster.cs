using System;
using System.Linq;
using System.Collections.Generic;

namespace RosterManagement
{
    public class CodeSchool
    {
        Dictionary<int, List<string>> _roster;

        public CodeSchool()
        {
            _roster = new Dictionary<int, List<String>>();
        }
        
        /// <summary>
        /// Should be able to Add Student to a Particular Wave
        /// </summary>
        /// <param name="cadet">Refers to the name of the Cadet</param>
        /// <param name="wave">Refers to the Wave number</param>
        public void Add(string cadet, int wave)
        {
            if (_roster.ContainsKey(wave))
            {
                _roster[wave].Add(cadet);
                _roster[wave].Sort();
            }
            else
            {
                List<string> cadets = new List<string>();
                cadets.Add(cadet);
                _roster.Add(wave, cadets);
            }
        }

        /// <summary>
        /// Returns all the Cadets in a given wave
        /// </summary>
        /// <param name="wave">Refers to the wave number from where cadet list is to be fetched</param>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Grade(int wave)
        {
            var list = new List<string>();
            try
            {
                list = _roster[wave];
            }
            catch(Exception e)
            {
                return list;
            }
            
            return list;
        }

        /// <summary>
        /// Return all the cadets in the CodeSchool
        /// </summary>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Roster()
        {
            SortedDictionary<int, List<string>> roster = new SortedDictionary<int, List<string>>(_roster);
            var cadets = new List<string>();
            foreach (KeyValuePair<int, List<string>> item in roster)
            {
                item.Value.Sort();
                foreach (string s in item.Value)
                {
                    cadets.Add(s);
                }
            }
            return cadets;
        }
    }
}
