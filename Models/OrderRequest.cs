using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMTAPI.Models
{
    /// <summary>
    /// The model used for the json request
    /// </summary>
    public class OrderRequest
    {
        public string User { get; set; }
        public string CustomerId { get; set; }

    }
}