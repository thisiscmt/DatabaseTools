using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBTools
{
    internal class ItemData
    {
        public ItemData()
        {
        }

        public ItemData(string name, int id)
        {
            this.Name = name;
            this.ID = id;
        }

        public ItemData(string name, string tag)
        {
            this.Name = name;
            this.Tag = tag;
        }

        public ItemData(string name, int id, string tag)
        {
            this.Name = name;
            this.ID = id;
            this.Tag = tag;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public string Name { get; set; }
        public int ID { get; set; }
        public string Tag { get; set; }
    }
}
