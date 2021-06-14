using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StokProgrami.Models;


namespace  StokProgramiApp
{
    public class Stock
    {
        public long id { get; set; }
        public long id_product { get; set; }
        public long stock_amount { get; set; }
    }
}
