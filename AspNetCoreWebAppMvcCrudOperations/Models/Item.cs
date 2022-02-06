using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AspNetCoreWebAppMvcCrudOperations.Models
{
    public class Item
    {
        //default identifier
        [Key]
        public int Id { get; set; }

        public string Borrower { get; set; }

        public string Lender { get; set; }

        [DisplayName("Item Name")]
        public string ItemName { get; set; }
    }
}
