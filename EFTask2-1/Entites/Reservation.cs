
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTask2.Entities
{
    public partial class Reservation
    {
       // [table]   => tobe mapped in DB OR in Context
        [Key]
        public int Id { get; set; }
        [Required]                              //validation exception will be raised if null
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string BirthDay { get; set; }

        [Required]
        [MaxLength(50)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(50)] 
        [Phone]                                         //DB not affected
        public string PhoneNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        [MaxLength]
        [EmailAddress]                                  //DB not affected
                                                        //For EF but for MVC it will be
        public string EmailAddress { get; set; }
        [Required]

        public int NumberGuest { get; set; }
        [Required]

        [Column(TypeName = "varchar(MAX)")]
        [MaxLength]
        public string StreetAddress { get; set; }
        [Required]
        [MaxLength(50)]

        public string AptSuite { get; set; }
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        [MaxLength]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]

        public string State { get; set; }

        [Required]
        [MaxLength(50)]

        public string ZipCode { get; set; }
        [Required]
        [MaxLength(50)]

        public string RoomType { get; set; }
        [Required]
        [MaxLength(50)]

        public string RoomFloor { get; set; }

        [Required]
        [MaxLength(50)]

        public string RoomNumber { get; set; }

        [Required]

        public double TotalBill { get; set; }

        [Required]
        [MaxLength(50)]

        public string PaymentType { get; set; }

        [Required]
        [MaxLength(50)]

        public string CardType { get; set; }

        [Required]
        [MaxLength(50)]

        public string CardNumber { get; set; }

        [Required]
        [MaxLength(50)]

        public string CardExp { get; set; }

        [Required]
        [MaxLength(50)]

        public string CardCvc { get; set; }

        [Required]

        public DateTime ArrivalTime { get; set; }

        [Required]

        public DateTime LeavingTime { get; set; }

        [Required]

        public bool CheckIn { get; set; }

        [Required]

        public int BreakFast { get; set; }

        [Required]

        public int Lunch { get; set; }

        [Required]

        public int Dinner { get; set; }

        [Required]

        public bool Cleaning { get; set; }

        [Required]

        public bool Towel { get; set; }

        [Required]

        public bool SSurprise { get; set; }

        [Required]

        public bool SupplyStatus { get; set; }

        [Required]

        public int FoodBill { get; set; }
    }
}