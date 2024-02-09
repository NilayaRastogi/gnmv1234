namespace Interview.Web.Models
{
    public class ProductCategories
    {
        public int InstanceId { get; set; }
        public int CategoryInstanceId { get; set; }
        public Product Product { get; set; }
        public Categories Categories { get; set; }
    }
}
