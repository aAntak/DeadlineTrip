using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class ShoppingCart
    {


        public int ShoppingCartId { get; set; }


        public Account account { get; set; }

        

    }
}
