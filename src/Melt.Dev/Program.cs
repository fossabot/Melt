// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Dev
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    internal class Program
    {

        [STAThread]
        private static void Main(string[] args)
        {
            var g = ConverterPool.Global;
            var table = new DataTable("TABLE");
            table.Columns.Add(new DataColumn("id", typeof(int)) { AutoIncrement = true, AutoIncrementSeed = 1 });
            table.Columns.Add(new DataColumn("name", typeof(string)));

            var row = table.NewRow();
            row["id"] = 1;
            row["name"] = "Yuyu";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = 2;
            row["name"] = "Alice";
            table.Rows.Add(row);

            table.AcceptChanges();

            var bytes = table.ToConstruct();
            Console.WriteLine(bytes);


            var t = bytes.ToDeconstruct().Detach<DataTable>();

            Console.WriteLine(t.Rows.Count);

            foreach (DataRow r in t.Rows)
            {
                Console.WriteLine(r["id"] + ": " + r["name"]);
            }

            Console.ReadKey();
            return;
        }   
    }
}


