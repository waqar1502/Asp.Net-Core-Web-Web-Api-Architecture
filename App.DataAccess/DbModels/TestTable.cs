using System;
using System.Collections.Generic;

namespace App.DataAccess.DbModels
{
    public partial class TestTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? NationalNo { get; set; }
    }
}
