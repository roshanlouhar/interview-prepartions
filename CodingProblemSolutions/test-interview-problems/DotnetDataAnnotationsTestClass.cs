using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestProblems
{
    public class DotnetDataAnnotationsTestClass
    {
        public DotnetDataAnnotationsTestClass() { }

        // add decorate the dataanotation attributes to the properties below

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Product Name")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Type must contain only letters")]
        public string Type { get; set; }

        [Range(0.01, 999999.99)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Range(0, long.MaxValue)]
        public long Quantity { get; set; }

        [Range(0.0f, 1000.0f)]
        public float Weight { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public bool IsDisabled { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }

        public string phoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }

        public string address { get; set; }

        [DataType(DataType.CreditCard)]
        public string creditsCardNumber { get; set; }

        [EnumDataType(typeof(Status))]
        public Status status { get; set; }

        public string displayName { get; set; }
    }

    public enum Status
    {
        Active,
        Inactive,
        Pending,
        Deleted
    }
}
