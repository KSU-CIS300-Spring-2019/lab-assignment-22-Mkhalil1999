using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        public ITrie Add(string s)
        {

            if (s != "")
            {
                
                TrieWithOneChild NewTrie = new TrieWithOneChild(s, isRooted);
                return NewTrie;
            }
            else
            {
                isRooted = true;
            }
            return this;
        }

        public bool Contains(string s)
        {
            if(s == "")
            {
                return isRooted;
            }
            else
            {
                return false;
            }
        }

        private bool isRooted = false;
    }
}
