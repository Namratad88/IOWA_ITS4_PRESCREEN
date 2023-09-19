using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IOWA.ITS4.PRESCREEN.DATAOBJECTS
{
    public class AdjacencyChecker_OP
    {

        private string _countyName;
        public virtual string countyName
        {
            get
            {
                return _countyName;
            }
            set
            {
                _countyName = value;

            }
        }
        private string _adjacentCountyName;
        public virtual string adjacentCountyName
        {
            get
            {
                return _adjacentCountyName;
            }
            set
            {
                _adjacentCountyName = value;

            }
        }


    }
}
