using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardHunt.classes
{
    public class Vote
    {
        /*
        ====================================================================
        Properties
        ====================================================================
         * */

        private int m_thumbsup;
        private int m_thumbsdown;

        //====================================================================
        //Constructor
        //====================================================================
        public Vote()
        {

        }
        
        public int thumbsup
         {
             get { return m_thumbsup; }
             set { m_thumbsup = value; }
         }

        public int thumbsdown
        {
            get { return m_thumbsdown; }
            set { m_thumbsdown = value; }
        }
    }
}