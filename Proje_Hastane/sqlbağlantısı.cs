﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    internal class sqlbağlantısı
    {
        public SqlConnection baglantı()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-UHPV4QF\\SQLEXPRESS01;Initial Catalog=HastaneProje;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
