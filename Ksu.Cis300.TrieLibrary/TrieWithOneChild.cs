using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// Implements trie interfacce for one child
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// adds string to child on 3 cases
        /// empty string bool is set to true
        /// non empty string and label equals chars first character substring is added to child
        /// otherwise new trie is mxde
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
           if(s == "")
            {
                _containsEmptyString = true;
                return this;
            }
           else if(s != "" && s[0] == _label)
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
                return this;
            }
            else
            {
                TrieWithManyChildren NewTrie = new TrieWithManyChildren(s, _containsEmptyString, _label, _onlyChild);
                return NewTrie;
            }
        }

        /// <summary>
        /// Checks cases against s
        /// empty string returns bool\
        /// if label is the same as s first character recursivley calls contains on childs string
        /// otherwise returns fasle
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {if (s == "")
            {
                return _containsEmptyString;
            }
            else if(_label == s[0])
            {
                return _onlyChild.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether a string is empty or not
        /// </summary>
        private bool _containsEmptyString;

        /// <summary>
        /// the only child
        /// </summary>
        private ITrie _onlyChild;

        /// <summary>
        /// Childs label
        /// </summary>
        private char _label;

        /// <summary>
        /// Constructor impements interace of ITrie
        /// Checks cases of string s if cases pass trie is impemented
        /// </summary>
        /// <param name="s"></param>
        /// <param name="isEmptyString"></param>
        public TrieWithOneChild(string s, bool isEmptyString)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _containsEmptyString = isEmptyString;

            _label = s[0];

            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1)); 
        }

    }
}
