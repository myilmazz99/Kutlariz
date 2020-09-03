using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kutlariz.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public CakeType CakeType { get; set; }
        public string CakeIngredients { get; set; }
        public string Message { get; set; }
        public byte CakeSize { get; set; }
        public string CakePicture { get; set; }
        public string BirthdayPersonName { get; set; }
        public string BirthdayPersonProfilePictureUrl { get; set; }
        public string AddressDescription { get; set; }
        public string Neigborhood { get; set; }
        public string State { get; set; }
        public Status Status { get; set; }
        public string UserId { get; set; }
        public double Price { get; set; }
        public PaymentType PaymentType { get; set; }
    }

    public enum CakeType
    {
        [Display(Name = "Butik")]
        Boutique,
        [Display(Name = "Kremalı")]
        Cream
    }

    public enum Status
    {
        [Display(Name = "Onay bekliyor")]
        WaitingConfirmation,
        [Display(Name = "Tamamlandı")]
        Completed,
        [Display(Name = "Onay verildi")]
        Confirmed
    }

    public enum PaymentType
    {
        [Display(Name = "Kredi/Banka Kartı")]
        Credit,
        [Display(Name = "Kapıda")]
        OnDoor
    }
}
