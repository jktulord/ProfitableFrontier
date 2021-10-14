using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Models.Heroes
{
    public static class Namer
    {
        public static List<string> NameList = new List<string>()
        {
        "Jonathan", "Joseph", "Jotaro", "Jolyne", "Gregory", "George", "Giorno", "Josuke", "Kira", "Johnny", "Jobin", "Yasuho", "Josephumi", "Joshu"
        };

        public static string GetRandName()
        {
            return NameList[Random.Range(0, NameList.Count)];
        }
    }
}
