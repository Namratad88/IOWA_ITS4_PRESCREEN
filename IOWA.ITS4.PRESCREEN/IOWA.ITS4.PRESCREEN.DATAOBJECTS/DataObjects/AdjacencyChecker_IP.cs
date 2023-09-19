using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IOWA.ITS4.PRESCREEN.DATAOBJECTS
{
    public class AdjacencyChecker_IP
    {

        private int _mapID;
        public virtual int mapID
        {
            get
            {
                return _mapID;
            }
            set
            {
                _mapID = value;

            }
        }
        private int _adjacentMapID;
        public virtual int adjacentMapID
        {
            get
            {
                return _adjacentMapID;
            }
            set
            {
                _adjacentMapID = value;

            }
        }

        private string _connectionString;
        public virtual string connectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;

            }
        }


    }
}
