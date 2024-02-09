using System;
using System.Collections.Generic;

namespace Interview.Web.Models
{
    public class Product
    {
        public int InstanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductImageUris { get; set; }
        public string ValidSkus { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public IList<ProductAttribute> ProductAttributes { get; set; }

}
}
