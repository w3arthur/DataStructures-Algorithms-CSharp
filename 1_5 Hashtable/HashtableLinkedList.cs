using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    public class HashtableLinkedList
    {
        private class Pair
        {
            public int Key { get; set; }
            public String Value { get; set; }
            public Pair(int key, String value) { Key = key; Value = value; }
        }
        private List<Pair>[] Hashtable { get; set; }
        public HashtableLinkedList() { Hashtable = new List<Pair>[5]; } //5 !!!
        private int HashFunction(int key) { return key % Hashtable.Length; }
        private List<Pair> GetList(int key) { return (List<Pair>)Hashtable.GetValue(HashFunction(key))!; }
        private bool BeginList(int key)
        {
            var list = GetList(key);
            if (list == null) { Hashtable[HashFunction(key)] = new List<Pair>(); return true; }
            return false;
        }
        private Pair? GetPair(int key)
        {
            var list = GetList(key);
            if (list is null) return null;
            foreach (var pair in list) if (pair.Key == key) return pair;
            return null;
        }
        public String? GetValue(int key)
        {
            var pair = GetPair(key);
            return pair is null ? null : pair.Value;
        }

        public void Put(int key, String value)
        {   // לחזור!
            var bucket = GetList(key);
            var pair = GetPair(key);
            if (! (BeginList(key) || pair is null)) { pair.Value = value; return; }
            Hashtable[HashFunction(key)].Add(new Pair(key, value));   //add last ?
        }

        public void Remove(int key)
        {
            var list = GetList(key);
            var pair = GetPair(key);
            if (list is null) throw new Exception();
            //foreach (var e in list) if (e.Key == key) { list.Remove(e); return; }
            list.Remove(pair!);
        }
        public override string ToString()
        {
            String str = "";
            int i = 1;
            foreach ( var list in Hashtable)
            {
                if (list is null) continue;
                foreach (var pair in list) 
                {
                    str += " | " + i + ")" + pair.Key + " " + pair.Value + " | ";
                }
                i++;
            }
            return str;
        }
    }
}
